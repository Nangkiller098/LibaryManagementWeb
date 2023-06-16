using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace LibaryManagementWeb.Models
{
    public class LeaveRequestCreateVM
    {
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        [Required]
        public int LeaveTypeId { get; set; }
        public SelectList LeaveType { get; set; }
        public string RequestComments { get; set; }

    }
}
