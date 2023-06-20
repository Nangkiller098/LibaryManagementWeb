using AutoMapper;
using LibaryManagementWeb.Contract;
using LibaryManagementWeb.Data;
using LibaryManagementWeb.Models;
using Microsoft.AspNetCore.Identity;
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

        public LeaveRequestRepository(ApplicationDbContext context,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ILeaveAllocationRepository leaveAllocationRepository,
            UserManager<Employee> userManager) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _leaveAllocationRepository = leaveAllocationRepository;
            _userManager = userManager;
        }

        //public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        //{
        //    //var leaveRequest = await GetAsync(leaveRequestId);
        //    //leaveRequest.Approved = approved;
        //    //if (approved)
        //    //{
        //    //    var allocation = await _leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmpolyeeId, leaveRequestId);
        //    //    int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
        //    //    allocation.NumberOfDays -= daysRequested;

        //    //    await _leaveAllocationRepository.UpdateAsync(allocation);
        //    //}
        //    //await UpdateAsync(leaveRequest);
        //    throw new NotImplementedException();
        //}

        public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            var leaveRequest = _mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmpolyeeId = user?.Id;
            await AddAsync(leaveRequest);

        }

        public async Task<List<LeaveRequest>> GetAllAsync(string employeeId)
        {
            return await _context.LeaveRequests.Where(q => q.RequestingEmpolyeeId == employeeId).ToListAsync();
        }

        public async Task<AdminiLeaveRequestViewVM> GetMyAdminiLeaveLists()
        {
            var leaveRequests = await _context.LeaveRequests.Include(q => q.LeaveType).ToListAsync();
            var model = new AdminiLeaveRequestViewVM
            {
                ToTalRequest = leaveRequests.Count,
                ApproveRequest = leaveRequests.Count(q => q.Approved == true),
                PendingRequest = leaveRequests.Count(q => q.Approved == null),
                RejectedRequested = leaveRequests.Count(q => q.Approved == false),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests),
            };
            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest.RequestingEmpolyeeId));
            }
            return model;
        }

        public async Task<EmployeeLeaveRequestVM> GetMyLeaveDetails()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            var allocation = (await _leaveAllocationRepository.GetEmployeeAllocation(user.Id)).LeaveAllocations;
            var requests = _mapper.Map<List<LeaveRequestVM>>(await GetAllAsync(user.Id));

            var model = new EmployeeLeaveRequestVM
            {
                LeaveAllocation = allocation,
                LeaveRequest = requests
            };
            return model;
        }


    }
}
