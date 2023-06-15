using LibaryManagementWeb.Contract;
using LibaryManagementWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibaryManagementWeb.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveAllocationRepository(ApplicationDbContext context, UserManager<Employee> userManager, ILeaveTypeRepository leaveTypeRepository) : base(context)
        {
            this._context = context;
            this._userManager = userManager;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId && q.Period == period);
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leavetype = await _leaveTypeRepository.GetAsync(leaveTypeId);
            var allocation = new List<LeaveAllocation>();

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
                await AddRangeAsync(allocation);
            }
            throw new NotImplementedException();
        }
    }
}
