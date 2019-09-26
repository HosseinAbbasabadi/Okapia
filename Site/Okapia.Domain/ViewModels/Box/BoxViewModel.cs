﻿using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.Box
{
    public class BoxViewModel
    {
        public int BoxId { get; set; }
        [Display(Name = "عنوان")] public string BoxTitle { get; set; }
        [Display(Name = "متن لینک")] public string BoxLinkText { get; set; }
        [Display(Name = "کد رنگ")] public string BoxColor { get; set; }
        [Display(Name = "عکس بنر باکس")] public string BoxBannerPicture { get; set; }
        public int BoxProvinceId { get; set; }
        [Display(Name = "استان")]
        public string BoxProvince { get; set; }
        public bool BoxIsEnabled { get; set; }

    }
}