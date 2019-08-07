using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.PageCategory
{
    public class PageCategoryViewModel
    {
        public int PageCategoryId { get; set; }
        [Display(Name = "نام")]
        public string PageCategoryName { get; set; }
        public int PageCategoryParentId { get; set; }
        [Display(Name = "رده مافوق")]
        public string PageCategoryParent { get; set; }
        public long PageCategoryRegisteringEmployeId { get; set; }
        [Display(Name = "کاربر ثبت کننده")]
        public string PageCategoryRegisteringEmploye { get; set; }
        [Display(Name = "عکس")]
        public string Photo { get; set; }
        public string PhotoAlt { get; set; }
        public bool PageCategoryIsDeleted { get; set; }
        [Display(Name = "تعداد صفحات رده")]
        public long PageCount { get; set; }
    }
}
