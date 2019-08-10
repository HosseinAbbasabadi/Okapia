using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.User
{
    public class IntroducedViewModel
    {
        public long UserId { get; set; }
        [Display(Name = "نام فارسی")] public string FullnameFa { get; set; }
        [Display(Name = "نام انگلیسی")] public string FullnameEn { get; set; }
        [Display(Name = "کدملی")] public string NationalCode { get; set; }
        [Display(Name = "موبایل")] public string Phonenumber { get; set; }
    }
}