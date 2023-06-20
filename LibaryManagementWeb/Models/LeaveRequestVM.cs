using System.ComponentModel.DataAnnotations;

namespace LibaryManagementWeb.Models
{
    public class LeaveRequestVM : LeaveRequestCreateVM
    {
        public int Id { get; set; }
        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }

        public new LeaveTypeVM LeaveType { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
        public string RequestingEmpolyeeId { get; set; }
        public EmployeeListVM Employee { get; set; }


    }
}
