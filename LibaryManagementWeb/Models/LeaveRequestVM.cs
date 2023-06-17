using LibaryManagementWeb.Data;
using System.ComponentModel.DataAnnotations;

namespace LibaryManagementWeb.Models
{
    public class LeaveRequestVM : LeaveRequestCreateVM
    {
        public int Id { get; set; }
        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }
        public LeaveType LeaveType { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }
}
