using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Okapia.Domain.ViewModels.Faq
{
    public class FaqViewModel
    {
        public long Id { get; set; }
        [Display(Name = "پرسش")] public string Question { get; set; }
        public long JobId { get; set; }
        [Display(Name = "شغل مربوطه")] public string Job { get; set; }
        [Display(Name = "آیا حذف شود؟")] public bool IsDeleted { get; set; }
        [Display(Name = "تاریخ ایجاد")] public string CreationDate { get; set; }
        [Display(Name = "کاربر ایجاد کننده")] public string CreatorUsername { get; set; }
    }
}