using System;
using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public long EmployeeId { get; set; }

        [Display(Name = "نام")] public string EmployeeFirstName { get; set; }

        [Display(Name = "نام خانوادگی")] public string EmployeeLastName { get; set; }

        [Display(Name = "کدملی")] public string EmployeeNationalCode { get; set; }
        [Display(Name = "موبایل")] public string EmployeeMobile { get; set; }

        [Display(Name = "نام کاربری")] public string EmployeeUsername { get; set; }

        [Display(Name = "تاریخ ایجاد")] public string EmployeeCreationDate { get; set; }

        [Display(Name = "آیا حذف شده است؟")] public bool EmployeeIsDeleted { get; set; }
        public string EmployeeFullname { get; set; }

        public long AccountId { get; set; }
    }
}