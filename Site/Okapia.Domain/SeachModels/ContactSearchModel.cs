using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.SeachModels
{
    public class ContactSearchModel : BaseSerachModel
    {
        [Display(Name = "نام ارسال کننده")] public string Name { get; set; }
        [Display(Name = "ایمیل ارسال کننده")] public string Email { get; set; }

        [Display(Name = "جستجو در بررسی شده ها")]
        public bool IsChecked { get; set; }
    }
}