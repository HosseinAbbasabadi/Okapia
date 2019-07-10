using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Employee
{
    public class CreateEmployee
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string EmployeeFirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string EmployeeLastName { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string EmployeeUsername { get; set; }

        [Display(Name = "کلمه رمز")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string EmployeePassword { get; set; }
    }
}