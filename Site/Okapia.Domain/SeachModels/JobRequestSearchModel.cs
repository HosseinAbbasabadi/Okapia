using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class JobRequestSearchModel : BaseSerachModel
    {
        [Display(Name = "عنوان شغلی")] public string Name { get; set; }
        [Display(Name = "نام رابط")] public string ContactTitle { get; set; }
        [Display(Name = "استان")] public int ProvinceId { get; set; }
        [Display(Name = "شهر")] public int CityId { get; set; }
        [Display(Name = "وضعیت")] public int Condition { get; set; }
        [Display(Name = "شماره پیگیری")] public long TrackingNumber { get; set; }
        public SelectList Provinces { get; set; }
    }
}