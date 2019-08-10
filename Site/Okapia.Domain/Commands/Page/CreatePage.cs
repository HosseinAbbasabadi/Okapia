using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.Page
{
    public class CreatePage
    {
        [Display(Name = "عنوان صفحه")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string PageTitle { get; set; }

        [Display(Name = "رده")]
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.PageCategoryRange)]
        public int PageCategoryId { get; set; }

        [Display(Name = "اسلاگ")] public string PageSlug { get; set; }

        [Display(Name = "متاتگ")]
        [MaxLength(80, ErrorMessage = "حد اکثر طور متاتگ ۸۰ کارکتر است")]
        public string PageMetaTag { get; set; }

        [Display(Name = "توضیحات متا")]
        [MaxLength(120, ErrorMessage = "حد اکثر طور توضیحات متا 120 کارکتر است")]
        public string PageMetaDesccription { get; set; }

        [Display(Name = "Seo Head")] public string PageSeohead { get; set; }

        [Display(Name = "آدرس کانونیکال")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string PageCanonicalAddress { get; set; }

        [Display(Name = "توضیحات کوتاه")] public string PageSmallDescription { get; set; }
        [Display(Name = "محتوا")] public string Content { get; set; }
        [Display(Name = "تاریخ انتشار")] public string PagePublishDate { get; set; }
        public DateTime PagePublishDateG { get; set; }
        public SelectList PageCategories { get; set; }
        public SelectList Employees { get; set; }
    }
}