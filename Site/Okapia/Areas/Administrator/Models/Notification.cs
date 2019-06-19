using System;
using System.ComponentModel.DataAnnotations;

namespace Okapia.Areas.Administrator.Models
{
    public class Notification
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "لینک ارجاع")]
        public string Link { get; set; }

        [Display(Name = "از تاریخ")]
        public DateTime FromDate { get; set; }

        [Display(Name = "تا تاریخ")]
        public DateTime ToDate { get; set; }
        
    }
}
