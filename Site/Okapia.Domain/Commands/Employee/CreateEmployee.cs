using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [Display(Name = "کد ملی")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = ValidationMessages.NationalCodeStringLength)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string EmployeeNationalCode { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
        [RegularExpression("^09[0-3][0-9]{8}$", ErrorMessage = ValidationMessages.ValidNumber)]
        public string EmployeeMobile { get; set; }

        [Display(Name = "کلمه رمز")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string EmployeePassword { get; set; }

        public List<string> SelectedControllers { get; set; }
        public List<SelectListItem> AvailableControllers { get; set; }
    }
}