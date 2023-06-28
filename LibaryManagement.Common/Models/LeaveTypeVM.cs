using System.ComponentModel.DataAnnotations;

namespace LibaryManagement.Common.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Display(Name = "Leave Type Name")]
        public string Name { get; set; }
        [Display(Name = "Default Number Of Days")]
        public int DefaultDays { get; set; }

    }
}
