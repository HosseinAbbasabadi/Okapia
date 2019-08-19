using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.Category
{
    public class CreateCategory
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string CategoryName { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string CategorySmallDescription { get; set; }

        [Display(Name = "اسلاگ")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string CategorySlug { get; set; }
        [Display(Name = "متاتگ")]
        [MaxLength(80, ErrorMessage = "حد اکثر طور متاتگ ۸۰ کارکتر است")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string CategoryMetaTag { get; set; }
        [Display(Name = "توضیحات متا")]
        [MaxLength(120, ErrorMessage = "حد اکثر طور توضیحات متا 120 کارکتر است")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string CategoryMetaDesccription { get; set; }
        [Display(Name = "هد سیو")] public string CategorySeohead { get; set; }
        [Display(Name = "عنوان صفحه")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string CategoryPageTittle { get; set; }
        [Display(Name = "گروه مافوق")] public int CategoryParentId { get; set; }
        [Display(Name = "عکس گروه")] public string NameImage { get; set; }
        public string TitleImage { get; set; }
        public string DescImage { get; set; }
        public string AltImage { get; set; }
        public SelectList Categories { get; set; }
    }
}