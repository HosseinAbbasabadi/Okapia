using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.PageCategory
{
    public class EditPageCategory : CreatePageCategory
    {
        public int PageCategoryId { get; set; }
        [Display(Name = "آیا حذف شود؟")] public bool PageCategoryIsDeleted { get; set; }

        [Display(Name = "آدرس صفحه جایگزین در صورت حذف")]
        public string PageCategoryRemoved301InsteadUrl { get; set; }
    }
}