using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Employee;

namespace Okapia.Areas.Administrator.Models
{
    public class EmployeeIndexViewModel
    {
        public EmployeeSearchModel EmployeeSearchModel { get; set; }
        public IEnumerable<EmployeeViewModel> EmployeeViewModels { get; set; }
    }
}
