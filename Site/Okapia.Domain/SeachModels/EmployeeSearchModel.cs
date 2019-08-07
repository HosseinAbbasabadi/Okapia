using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.SeachModels
{
    public class EmployeeSearchModel : BaseSerachModel
    {
        [Display(Name = "نام")] public string EmployeeFirstName { get; set; }
        [Display(Name = "نام خانوادگی")] public string EmployeeLastName { get; set; }
        [Display(Name = "کدملی")] public string EmployeeNationalCode { get; set; }
        [Display(Name = "نام کاربری")] public string EmployeeUsername { get; set; }
        [Display(Name = "جستجو در حذف شده ها")] public bool EmployeeIsDeleted { get; set; }
    }
}