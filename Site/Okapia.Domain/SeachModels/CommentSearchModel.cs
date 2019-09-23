using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.SeachModels
{
    public class CommentSearchModel : BaseSerachModel
    {
        [Display(Name = "بخش مربوطه")]
        public string CommentOwner { get; set; }
        [Display(Name = "جستجو در تایید شده ها")]
        public bool CommentIsConfirmed { get; set; }
        [Display(Name = "جستجو در حذف شده ها")]
        public bool CommentIsDeleted { get; set; }
    }
}