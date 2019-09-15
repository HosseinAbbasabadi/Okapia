using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Box
{
    public class CreateBox
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string BoxTitle { get; set; }

        [Display(Name = "لینک")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string BoxLink { get; set; }

        [Display(Name = "متن لینک")] public string BoxLinkText { get; set; }
        [Display(Name = "متن دکمه")] public string BoxLinkBtnText { get; set; }
        [Display(Name = "کد رنگ")] public string BoxColor { get; set; }
        [Display(Name = "آیکون")] public string BoxIcon { get; set; }
        public string BoxBannerPicture { get; set; }

        [Display(Name = "لینک عکس بنر")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string BoxBannerPictureLink { get; set; }

        public string BoxBannerPictureAlt { get; set; }
        public string BoxBannerPictureTitle { get; set; }
        [Display(Name = "آیا بنر فعال باشد؟")] public bool BoxBannerPictureIsEnabled { get; set; }
    }
}