using System.ComponentModel.DataAnnotations;

namespace LibaryManagement.Common.Models
{
    public class AdminiLeaveRequestViewVM
    {
        [Display(Name = "Total Number Of Request")]
        public int ToTalRequest { get; set; }
        [Display(Name = "Approved Request")]
        public int ApproveRequest { get; set; }
        [Display(Name = "Pending Request")]
        public int PendingRequest { get; set; }
        [Display(Name = "Rejected Request")]
        public int RejectedRequested { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }
}
