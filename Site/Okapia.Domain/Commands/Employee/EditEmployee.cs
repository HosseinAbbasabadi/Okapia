using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.EmployeeController;

namespace Okapia.Domain.Commands.Employee
{
    public class EditEmployee : CreateEmployee
    {
        public long EmployeeId { get; set; }

        [Display(Name = "آیا حذف شود؟")]
        public bool EmployeeIsDeleted { get; set; }
        public List<EmployeeControllerViewModel> ExistingControllers { get; set; }

    }
}