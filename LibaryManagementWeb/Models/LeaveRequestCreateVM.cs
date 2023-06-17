using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LibaryManagementWeb.Models
{
    public class LeaveRequestCreateVM : IValidatableObject
    {

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int LeaveTypeId { get; set; }
        public SelectList LeaveType { get; set; }
        public string RequestComments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate)
            {
                yield return new ValidationResult("The Start Date Must Be Beofre End date", new[] { nameof(StartDate), nameof(EndDate) });
            }
            if (RequestComments?.Length > 250)
            {
                yield return new ValidationResult("Commend Too Long", new[] { nameof(RequestComments) });
            }


        }
    }
}
