using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategorySlug { get; set; }
        [Display(Name = "نام")] public string CategoryName { get; set; }
        [Display(Name = "توضیحات")] public string CategorySmallDescription { get; set; }
        [Display(Name ="رنگ")]
        public string CategoryColor { get; set; }
        public int CategoryParentId { get; set; }
        [Display(Name = "عنوان گروه مافوق")] public string CategoryParentName { get; set; }
        [Display(Name = "عکس")] public string Photo { get; set; }
        [Display(Name = "آیا حذف شده است؟")] public bool IsDeleted { get; set; }
    }
}