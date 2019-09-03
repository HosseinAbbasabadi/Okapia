using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام ارسال کننده")] public string Name { get; set; }
        [Display(Name = "ایمیل ارسال کننده")] public string Email { get; set; }
        [Display(Name = "پیام ارسال شده")] public string Message { get; set; }
        [Display(Name = "تاریخ ارسال")] public string CreationDate { get; set; }
        public bool IsChecked { get; set; }
    }
}