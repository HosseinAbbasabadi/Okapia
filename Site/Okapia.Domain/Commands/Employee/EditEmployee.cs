using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Employee
{
    public class EditEmployee : CreateEmployee
    {
        public int EmployeeId { get; set; }

        [Display(Name = "آیا حذف شود؟")]
        public bool EmployeeIsDeleted { get; set; }
    }
}