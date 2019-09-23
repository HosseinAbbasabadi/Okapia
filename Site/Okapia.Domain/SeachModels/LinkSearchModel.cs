using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class LinkSearchModel : BaseSerachModel
    {
        [Display(Name = "نام لینک")] public string Label { get; set; }

        [Display(Name = "جستجو در حذف شده ها")]
        public bool IsDeleted { get; set; }

        [Display(Name = "گروه")] public int Group { get; set; }
        public SelectList LinkGroups { get; set; }
    }
}