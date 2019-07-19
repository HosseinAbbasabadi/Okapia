using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.Modal
{
    public class CreateModal
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Title { get; set; }

        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Message { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string StartDate { get; set; }

        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string EndDate { get; set; }

        public DateTime StartDateG { get; set; }
        public DateTime EndDateG { get; set; }

        [Display(Name = "گروه")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public int GroupId { get; set; }

        [Display(Name = "لنیک صفحه")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string PageLink { get; set; }

        public SelectList Groups { get; set; }
        [Display(Name = "نام عکس")] public string PicName { get; set; }
        [Display(Name = "عنوان عکس")] public string PicTitle { get; set; }
        [Display(Name = "Alt")] public string PicAlt { get; set; }
        [Display(Name = "توضیحات")] public string PicDescription { get; set; }
    }
}