using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Page
{
    public class EditPage : CreatePage
    {
        public long PageId { get; set; }
        [Display(Name = "آیا حذف شود؟")] public bool PageIsDeleted { get; set; }

        [Display(Name = "آدرس صفحه جایگزین در صورت حذف")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string PageRemoved301InsteadUrl { get; set; }
    }
}