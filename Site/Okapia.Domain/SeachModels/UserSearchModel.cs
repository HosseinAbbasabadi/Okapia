using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class UserSearchModel : BaseSerachModel
    {
        [Display(Name = "نام")]
        public string UserFirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        public string UserLastName { get; set; }
        [Display(Name = "کدملی")]
        public string UserNationalCode { get; set; }
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }
        [Display(Name = "موبایل")]
        public string UserPhoneNumber { get; set; }
        [Display(Name = "استان")]
        public int UserProvinceId { get; set; }
        [Display(Name = "شهر")]
        public int UserCityId { get; set; }
        [Display(Name = "منطقه")]
        public int UserDistrictId { get; set; }
        [Display(Name = "محله")]
        public int UserNeighborhoodId { get; set; }
        [Display(Name = "جستجو در حذف شده ها")]
        public bool IsDeleted { get; set; }
        public SelectList Provinces { get; set; }
    }
}
