using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.SeachModels
{
    public class BoxSearchModel : BaseSerachModel
    {
        [Display(Name = "عنوان")]
        public string BoxTitle { get; set; }
        [Display(Name = "جستجو در غیر فعال ها")]
        public bool BoxIsEnabled { get; set; }
    }
}
