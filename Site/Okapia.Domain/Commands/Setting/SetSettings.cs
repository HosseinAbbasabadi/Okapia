using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Setting
{
    public class SetSettings
    {
        [Display(Name = "درباره ما")] public string About { get; set; }
        [Display(Name = "درباره عکس درباره")] public string AboutPicture { get; set; }
        [Display(Name = "Alt")] public string AboutPictureAlt { get; set; }
        [Display(Name = "عنوان عکس")] public string AboutPictureTitle { get; set; }

        [Display(Name = "درباره (نمایش در فوتر)")]
        public string FooterAbout { get; set; }

        [Display(Name = "آدرس")] public string Address { get; set; }

        [Display(Name = "شماره تلفن 1")]
        [MaxLength(11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Tell1 { get; set; }

        [Display(Name = "شماره تلفن 2")]
        [MaxLength(11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Tell2 { get; set; }

        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = ValidationMessages.Email)]
        public string Email { get; set; }

        [Display(Name = "نقشه")] public string Map { get; set; }

        [Display(Name = "متاتگ ها")]
        [MaxLength(80, ErrorMessage = "حداکثر طول کلمات کلیدی ۸۰ کاراکتر است")]
        public string MetaTags { get; set; }

        [Display(Name = "توضیحات متا")]
        [MaxLength(120, ErrorMessage = "حداکثر طول توضیحات متا ۱۲۰ کاراکتر است")]
        public string MetaDescription { get; set; }

        [Display(Name = "آدرس کانونیکال")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string CanonicalAddress { get; set; }
    }
}