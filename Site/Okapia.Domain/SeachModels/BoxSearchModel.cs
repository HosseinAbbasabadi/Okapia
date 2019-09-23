using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class BoxSearchModel : BaseSerachModel
    {
        [Display(Name = "عنوان")] public string BoxTitle { get; set; }

        [Display(Name = "جستجو در غیر فعال ها")]
        public bool BoxIsEnabled { get; set; }

        [Display(Name = "نمایش باکس های استان:")]
        public int BoxProvinceId { get; set; }

        public SelectList Provinces { get; set; }
    }
}