using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class CitySearchModel : BaseSerachModel
    {
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "استان")]
        public int ProvinceId { get; set; }
        [Display(Name = "آیا حذف شده است؟")]
        public bool IsDeleted { get; set; }
        public SelectList Provinces { get; set; }
    }
}
