using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class SlideSearchModel : BaseSerachModel
    {
        [Display(Name = "از تاریخ ایجاد")] public string SlideFromCreationDate { get; set; }
        [Display(Name = "تا تاریخ ایجاد")] public string SlideToCreationDate { get; set; }
        public DateTime SlideFromCreationDateG { get; set; }
        public DateTime SlideToCreationDateG { get; set; }

        [Display(Name = "جستجو در حذف ها")]
        public bool SlideIsDeleted { get; set; }
        [Display(Name = "استان")] public int SlideProvinceId { get; set; }
        public SelectList Provinces { get; set; }
    }
}