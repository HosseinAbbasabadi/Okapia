using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.PageCategory
{
    public class CreatePageCategory
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string PageCategoryName { get; set; }


        [Display(Name = "عکس")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string NameImage { get; set; }

        [Display(Name = "عنوان")] public string TitleImage { get; set; }
        [Display(Name = "توضیحات")] public string DescImage { get; set; }
        [Display(Name = "alt")] public string AltImage { get; set; }

        [Display(Name = "عنوان صفحه")] public string PageCategoryPageTitle { get; set; }
        [Display(Name = "اسلاگ")] public string PageCategorySlug { get; set; }

        [Display(Name = "متاتگ")]
        [MaxLength(80, ErrorMessage = "حد اکثر طور متاتگ ۸۰ کارکتر است")]
        public string PageCategoryMetaTag { get; set; }

        [Display(Name = "توضیحات متا")]
        [MaxLength(120, ErrorMessage = "حد اکثر طور توضیحات متا 120 کارکتر است")]
        public string PageCategoryMetaDesccription { get; set; }

        [Display(Name = "Seo Head")] public string PageCategorySeohead { get; set; }

        [Display(Name = "آدرس کانونیکال")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string PageCanonicalAddress { get; set; }

        [Display(Name = "رده مافوق")]
        public int PageCategoryParentId { get; set; }

        [Display(Name = "ترتیب نمایش")] public int PageCategoryShowOrder { get; set; }
        public SelectList PageCategories { get; set; }
    }
}