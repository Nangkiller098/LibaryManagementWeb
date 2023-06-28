using LibaryManagement.Common.Models;
using LibaryManagement.Data;

namespace LibaryManagement.Application.Contract
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task LeaveAllocation(int leaveTypeId);
        Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period);
        Task<LeaveAllocation> GetEmployeeAllocation(string employeeId, int leaveTypeId);
        Task<EmployeeAllocationVM> GetEmployeeAllocation(string employeeId);
        Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id);
        Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model);
    }
}
