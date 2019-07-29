using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.ViewModels.User
{
    public class UserDetailsViewModel : UserViewModel
    {
        [Display(Name = "نام انگلیسی")]
        public string NameEn { get; set; }
        [Display(Name = "نام خانوادگی انگلیسی")]
        public string FamilyEn { get; set; }
        [Display(Name = "نام فارسی")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی فارسی")]
        public string Family { get; set; }
        [Display(Name = "منطقه")]
        public string District { get; set; }
        [Display(Name = "محله")]
        public string Neighborhood { get; set; }
        [Display(Name = "کارت اول")]
        public string Card1 { get; set; }
        [Display(Name = "کارت دوم")]
        public string Card2 { get; set; }
        [Display(Name = "کارت سوم")]
        public string Card3 { get; set; }
        [Display(Name = "کارت چهارم")]
        public string Card4 { get; set; }
        [Display(Name = "کارت پنجم")]
        public string Card5 { get; set; }
        [Display(Name = "کارت ششم")]
        public string Card6 { get; set; }
        [Display(Name = "کارت هفتم")]
        public string Card7 { get; set; }
        [Display(Name = "کارت هشتم")]
        public string Card8 { get; set; }
        [Display(Name = "کارت نهم")]
        public string Card9 { get; set; }
        [Display(Name = "کارت دهم")]
        public string Card10 { get; set; }
    }
}
