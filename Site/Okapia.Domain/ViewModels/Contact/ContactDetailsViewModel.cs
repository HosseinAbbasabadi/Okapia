using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.Contact
{
    public class ContactDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام ارسال کننده")] public string Name { get; set; }
        [Display(Name = "ایمیل ارسال کننده")] public string Email { get; set; }
        [Display(Name = "پیام ارسال شده")] public string Message { get; set; }
        [Display(Name = "تاریخ ارسال")] public string CreationDate { get; set; }

        [Display(Name = "بررسی کننده")]
        public string CheckerName { get; set; }

        [Display(Name = "تاریخ بررسی")] public string CheckDate { get; set; }
    }
}