using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.Category
{
    public class CreateCategory
    {
        [Display(Name = "نام")]
        public string CategoryName { get; set; }
        [Display(Name = "توضیحات کوتاه")]
        public string CategorySmallDescription { get; set; }
        [Display(Name = "متاتگ")]
        public string CategoryMetaTag { get; set; }
        [Display(Name = "توضیحات متا")]
        public string CategoryMetaDesccription { get; set; }
        [Display(Name = "هد سیو")]
        public string CategorySeohead { get; set; }
        [Display(Name = "عنوان صفحه")]
        public string CategoryPageTittle { get; set; }
        [Display(Name = "گروه مافوق")]
        public int CategoryParentId { get; set; }
        [Display(Name = "گروه مافوق")]
        public SelectList Categories { get; set; }
        [Display(Name = "عکس گروه")]
        public string NameImage { get; set; }
    }
}
