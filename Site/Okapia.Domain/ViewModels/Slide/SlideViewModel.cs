﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.Slide
{
    public class SlideViewModel
    {
        public int SlideId { get; set; }
        [Display(Name = "عکس")] public string SlideName { get; set; }
        [Display(Name = "عنوان اصلی")] public string SlideTitleText { get; set; }
        [Display(Name = "توضیح عنوان")] public string SlideDescriptionText { get; set; }
        [Display(Name = "تاریخ ایجاد")] public string SlideCreationDate { get; set; }
        public DateTime SlideCreationDateG { get; set; }
        public bool SlideIsDeleted { get; set; }
    }
}