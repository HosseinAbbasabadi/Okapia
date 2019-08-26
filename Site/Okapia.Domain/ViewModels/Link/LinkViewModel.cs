using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Okapia.Domain.ViewModels.Link
{
    public class LinkViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام لینک")] public string Label { get; set; }
        [Display(Name = "آدرس لینک")] public string Target { get; set; }
        [Display(Name = "گروه")] public int Category { get; set; }
        [Display(Name = "تاریخ ایجاد")] public string CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}