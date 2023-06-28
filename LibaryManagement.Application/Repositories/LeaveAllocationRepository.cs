using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibaryManagement.Application.Contract;
using LibaryManagement.Common.Constants;
using LibaryManagement.Common.Models;
using LibaryManagement.Data;
using LibaryManagementWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LibaryManagementWeb.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IEmailSender _emailSender;

        public LeaveAllocationRepository(ApplicationDbContext context,
            UserManager<Employee> userManager,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper,
            AutoMapper.IConfigurationProvider configurationProvider,
            IEmailSender emailSender
            ) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
            _emailSender = emailSender;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId && q.Period == period);
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocation(string employeeId)
        {
            var alloction = await _context.LeaveAllocations
                //include mean innerjoin
                .Include(q => q.LeaveType)
                .Where(q => q.EmployeeId == employeeId)
                .ProjectTo<LeaveAllocationVM>(_configurationProvider)
                 .ToListAsync();
            var employee = await _userManager.FindByIdAsync(employeeId);
            var employeeAllocationModel = _mapper.Map<EmployeeAllocationVM>(employee);
            employeeAllocationModel.LeaveAllocations = _mapper.Map<List<LeaveAllocationVM>>(alloction);
            return employeeAllocationModel;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id)
        {
            var alloction = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (alloction == null)
            {
                return null;
            }
            var employee = await _userManager.FindByIdAsync(alloction.EmployeeId);

            var model = _mapper.Map<LeaveAllocationEditVM>(alloction);
            model.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(alloction.EmployeeId));

            return model;
        }

        public async Task<LeaveAllocation> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId);
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leavetype = await _leaveTypeRepository.GetAsync(leaveTypeId);
            var allocation = new List<LeaveAllocation>();
            var employeeWithNewAllocations = new List<Employee>();

            foreach (var employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                {
                    continue;
                }
                allocation.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumberOfDays = leavetype.DefaultDays
                });
                employeeWithNewAllocations.Add(employee);
            }
            await AddRangeAsync(allocation);

            foreach (var employee in employeeWithNewAllocations)
            {
                await _emailSender.SendEmailAsync(employee.Email, $"Leave Allocation Posted for {period}", $"Your {leavetype.Name} +" +
                    $"has been posted for the period fo {period}. You have been given {leavetype.DefaultDays}");
            }
        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model)
        {
            var leaveAllocation = await GetAsync(model.Id);
            if (leaveAllocation == null)
            {
                return false;
            }
            leaveAllocation.Period = model.Period;
            leaveAllocation.NumberOfDays = model.NumberOfDays;
            await UpdateAsync(leaveAllocation);

            return true;
        }
    }
}
