using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Okapia.Domain.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [Display(Name = "نام")] public string CategoryName { get; set; }
        [Display(Name = "توضیحات")] public string CategorySmallDescription { get; set; }
        public int CategoryParentId { get; set; }
        [Display(Name = "عنوان گروه مافوق")] public string CategoryParentName { get; set; }
        [Display(Name = "عکس")] public string Photo { get; set; }
        [Display(Name = "آیا حذف شده است؟")] public bool IsDeleted { get; set; }
    }
}