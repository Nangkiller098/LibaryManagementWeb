using LibaryManagementWeb.Data;
using LibaryManagementWeb.Models;

namespace LibaryManagementWeb.Contract
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<EmployeeLeaveRequestVM> GetMyLeaveDetails();
        Task<LeaveRequestVM> GetLeaveRequestAsync(int id);
        Task<List<LeaveRequestVM>> GetAllAsync(string employeeId);
        Task ChangeApprovalStatus(int leaveRequestId, bool approved);
        Task CancelLeaveRequest(int leaveRequestId);
        Task<AdminiLeaveRequestViewVM> GetMyAdminiLeaveLists();
    }
}
