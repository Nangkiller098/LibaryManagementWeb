using System.ComponentModel.DataAnnotations;

namespace LibaryManagement.Common.Models
{
    public class LeaveRequestVM : LeaveRequestCreateVM
    {
        public int Id { get; set; }
        [Display(Name = "Date Requested")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DateRequested { get; set; }

        public new LeaveTypeVM LeaveType { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
        public string RequestingEmpolyeeId { get; set; }
        public EmployeeListVM Employee { get; set; }


    }
}
