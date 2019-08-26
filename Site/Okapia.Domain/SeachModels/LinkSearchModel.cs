using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.SeachModels
{
    public class LinkSearchModel : BaseSerachModel
    {
        [Display(Name = "نام لینک")] public string Label { get; set; }
        [Display(Name = "گروه")] public int Category { get; set; }

        [Display(Name = "جستجو در حذف شده ها")]
        public bool IsDeleted { get; set; }
    }
}