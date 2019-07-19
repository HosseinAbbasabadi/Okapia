using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.User
{
    public class UserViewModel
    {
        public long UserId { get; set; }
        [Display(Name = "نام کامل")] public string UserFullName { get; set; }
        [Display(Name = "نام کاربری")] public string Username { get; set; }
        [Display(Name = "کدملی")] public string UserNationalCode { get; set; }
        [Display(Name = "تلفن")] public string UserPhoneNumber { get; set; }
        public int UserProvinceId { get; set; }
        [Display(Name = "استان")] public string UserProvince { get; set; }
        public int UserCityId { get; set; }
        [Display(Name = "شهر")] public string UserCity { get; set; }
        [Display(Name = "منطقه")] public int UserDistrictId { get; set; }
        [Display(Name = "محله")] public int UserNeighborhoodId { get; set; }
        [Display(Name = "آدرس")] public string UserAddress { get; set; }
        [Display(Name = "کدپستی")] public string UserPostalCode { get; set; }
        [Display(Name = "ایمیل")] public string UserEmail { get; set; }
        [Display(Name = "تاریخ تولد")] public string UserBirthDate { get; set; }
        [Display(Name = "تاریخ ثبت نام")] public string UserRegistrationDate { get; set; }
        [Display(Name = "نام کاربری")] public string UserName { get; set; }
        public long AccountId { get; set; }
        public bool IsDeleted { get; set; }
    }
}