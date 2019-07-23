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
        [Display(Name = "وضعیت")] public int SelectedStatus { get; set; }

        [Display(Name = "شماره پیگیری")]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public long TrackingNumber { get; set; }

        public SelectList Provinces { get; set; }
    }
}