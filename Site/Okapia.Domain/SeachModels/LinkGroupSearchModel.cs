using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.SeachModels
{
    public class LinkGroupSearchModel : BaseSerachModel
    {
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "جستجو در حذف شده ها")]
        public bool IsDeleted { get; set; }
    }
}