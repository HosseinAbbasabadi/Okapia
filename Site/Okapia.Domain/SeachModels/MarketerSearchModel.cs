using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class MarketerSearchModel : BaseSerachModel
    {
        [Display(Name = "نام")] public string MarketerFirstName { get; set; }
        [Display(Name = "نام خانوادگی")] public string MarketerLastName { get; set; }
        [Display(Name = "کد ملی")] public string MarketerNationalCode { get; set; }
        [Display(Name = "شماره موبایل")] public string MarketerMobile { get; set; }
        [Display(Name = "استان")] public int MarketerProvinceId { get; set; }
        [Display(Name = "شهر")] public int MarketerCityId { get; set; }
        [Display(Name = "منطقه")] public int MarketerDistrictId { get; set; }
        [Display(Name = "محله")] public int MarketerNeighborhoodId { get; set; }

        [Display(Name = "جستجو در حذف شده ها")]
        public bool MarketerIsDeleted { get; set; }

        public SelectList Provinces { get; set; }
    }
}