namespace LibaryManagementWeb.Models
{
    public class EmployeeLeaveRequestVM
    {
        //public EmployeeLeaveRequestVM(List<LeaveAllocationVM>? allocation, List<LeaveRequestVM>? requests)
        //{
        //    allocation = LeaveAllocation;
        //    requests = LeaveRequest;
        //}
        public List<LeaveAllocationVM> LeaveAllocation { get; set; }
        public List<LeaveRequestVM> LeaveRequest { get; set; }

    }
}
