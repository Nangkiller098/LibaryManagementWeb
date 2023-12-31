﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibaryManagement.Application.Contract;
using LibaryManagement.Common.Models;
using LibaryManagement.Data;
using LibaryManagementWeb.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LibaryManagementWeb.Repositories
{

    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly UserManager<Employee> _userManager;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IEmailSender _emailSender;

        public LeaveRequestRepository(ApplicationDbContext context,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ILeaveAllocationRepository leaveAllocationRepository,
            UserManager<Employee> userManager,
            AutoMapper.IConfigurationProvider configurationProvider,
            IEmailSender emailSender
            ) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _leaveAllocationRepository = leaveAllocationRepository;
            _userManager = userManager;
            _configurationProvider = configurationProvider;
            _emailSender = emailSender;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Cancelled = true;
            await UpdateAsync(leaveRequest);
            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmpolyeeId);

            await _emailSender.SendEmailAsync(user.Email, $"Leave Request Cancel", $"Your Leave Request from" +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been Cancel");
        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Approved = approved;
            if (approved)
            {
                var allocation = await _leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmpolyeeId, leaveRequest.LeaveTypeId);
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDays -= daysRequested;

                await _leaveAllocationRepository.UpdateAsync(allocation);
            }
            await UpdateAsync(leaveRequest);


            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmpolyeeId);
            var approvalStatus = approved ? "Approved" : "Declined";
            await _emailSender.SendEmailAsync(user.Email, $"Leave Request {approvalStatus}", $"Your Leave Request from" +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been {approvalStatus}");
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            var leaveAllocation = await _leaveAllocationRepository.GetEmployeeAllocation(user.Id, model.LeaveTypeId);

            if (leaveAllocation == null)
            {
                return false;
            }
            int dayRequested = (int)(model.EndDate.Value - model.StartDate.Value).TotalDays;
            if (dayRequested > leaveAllocation.NumberOfDays)
            {
                return false;
            }
            var leaveRequest = _mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmpolyeeId = user?.Id;
            await AddAsync(leaveRequest);


            return true;

        }

        public async Task<List<LeaveRequestVM>> GetAllAsync(string employeeId)
        {
            return await _context.LeaveRequests.Where(q => q.RequestingEmpolyeeId == employeeId)
                .ProjectTo<LeaveRequestVM>(_configurationProvider)
                .ToListAsync();
        }

        public async Task<LeaveRequestVM> GetLeaveRequestAsync(int id)
        {
            var leaveRequest = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (leaveRequest == null)
            {
                return null;
            }
            var model = _mapper.Map<LeaveRequestVM>(leaveRequest);
            model.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest.RequestingEmpolyeeId));
            return model;
        }

        public async Task<AdminiLeaveRequestViewVM> GetMyAdminiLeaveLists()
        {
            var leaveRequests = await _context.LeaveRequests
                //.Where(q => q.Cancelled == false)
                .Include(q => q.LeaveType)
                .ToListAsync();
            var model = new AdminiLeaveRequestViewVM
            {
                //ToTalRequest = leaveRequests.Count(q => q.Cancelled == false),
                ToTalRequest = leaveRequests.Count,
                ApproveRequest = leaveRequests.Count(q => q.Approved == true),
                PendingRequest = leaveRequests.Count(q => q.Approved == null && q.Cancelled == false),
                RejectedRequested = leaveRequests.Count(q => q.Approved == false),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests),
            };
            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee = _mapper.Map<EmployeeListVM>(await _userManager
                    .FindByIdAsync(leaveRequest.RequestingEmpolyeeId));
            }
            return model;
        }

        public async Task<EmployeeLeaveRequestVM> GetMyLeaveDetails()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            var allocation = (await _leaveAllocationRepository.GetEmployeeAllocation(user.Id)).LeaveAllocations;
            var requests = await GetAllAsync(user.Id);

            var model = new EmployeeLeaveRequestVM
            {
                LeaveAllocation = allocation,
                LeaveRequest = requests
            };
            return model;
        }

    }
}
