using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Setting
{
    public class SettingDto
    {
        [Display(Name = "درباره ما")] public string About { get; set; }
        [Display(Name = "عکس درباره")] public string AboutPicture { get; set; }
        [Display(Name = "Alt")] public string AboutPictureAlt { get; set; }
        [Display(Name = "عنوان عکس")] public string AboutPictureTitle { get; set; }

        [Display(Name = "درباره (نمایش در فوتر)")]
        public string FooterAbout { get; set; }

        [Display(Name = "قوانین و مقررات")] public string Privacy { get; set; }

        [Display(Name = "آدرس")] public string Address { get; set; }

        [Display(Name = "شماره تلفن پشتیبانی")]
        [MaxLength(11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Tell1 { get; set; }

        [Display(Name = "شماره تلفن شرکت")]
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

        [Display(Name = "لینک فیس بوک")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string Facebook { get; set; }

        [Display(Name = "لینک اینستاگرام")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string Instagram { get; set; }

        [Display(Name = "لینک تلگرام")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string Telegram { get; set; }

        [Display(Name = "لینک توییتر")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string Twitter { get; set; }

        [Display(Name = "عنوان بخش مراکز منتخب")]
        public string FeaturedJobsTitle { get; set; }

        [Display(Name = "متن پیام فراموشی رمز عبور")]
        public string ForgetPasswordText { get; set; }

        [Display(Name = "عکس بنر")] public string BannerPicture { get; set; }
        [Display(Name = "عنوان عکس بنر")] public string BannerPictureTitle { get; set; }
        [Display(Name = "alt عکس بنر")] public string BannerPictureAlt { get; set; }
        [Display(Name = "لینک بنر")] public string BannerLink { get; set; }

        [Display(Name = "آیا بنر بالای سایت نمایش داده شود؟")]
        public string BannerIsActive { get; set; }

        [Display(Name = "رنگ پس زمینه ناحیه بنر")]
        public string BannerBackgroundColor { get; set; }

        [Display(Name = "عکس پیشنهاد ویژه اول")]
        public string SpecialSuggestionPicture1 { get; set; }

        [Display(Name = "Alt عکس پیشنهاد ویژه اول")]
        public string SpecialSuggestionPictureAlt1 { get; set; }

        [Display(Name = "عنوان عکس پیشنهاد ویژه اول")]
        public string SpecialSuggestionPictureTitle1 { get; set; }

        [Display(Name = "لینک پیشنهاد ویژه اول")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string SpecialSuggestionPictureLink1 { get; set; }

        [Display(Name = "عکس پیشنهاد ویژه دوم")]
        public string SpecialSuggestionPicture2 { get; set; }

        [Display(Name = "Alt عکس پیشنهاد ویژه دوم")]
        public string SpecialSuggestionPictureAlt2 { get; set; }

        [Display(Name = "عنوان عکس پیشنهاد ویژه دوم")]
        public string SpecialSuggestionPictureTitle2 { get; set; }

        [Display(Name = "لینک پیشنهاد ویژه دوم")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string SpecialSuggestionPictureLink2 { get; set; }

        [Display(Name = "عکس پیشنهاد ویژه سوم")]
        public string SpecialSuggestionPicture3 { get; set; }

        [Display(Name = "Alt عکس پیشنهاد ویژه سوم")]
        public string SpecialSuggestionPictureAlt3 { get; set; }

        [Display(Name = "عنوان عکس پیشنهاد ویژه سوم")]
        public string SpecialSuggestionPictureTitle3 { get; set; }

        [Display(Name = "لینک پیشنهاد ویژه سوم")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string SpecialSuggestionPictureLink3 { get; set; }

        [Display(Name = "عنوان فوتر باکس اول")]
        public string FooterBoxTitle1 { get; set; }
        [Display(Name = "متن فوتر باکس اول")]
        public string FooterBoxText1 { get; set; }
        [Display(Name = "آیکون فوتر باکس اول")]
        public string FooterBoxIcon1 { get; set; }

        [Display(Name = "عنوان فوتر باکس دوم")]
        public string FooterBoxTitle2 { get; set; }
        [Display(Name = "متن فوتر باکس دوم")]
        public string FooterBoxText2 { get; set; }
        [Display(Name = "آیکون فوتر باکس دوم")]
        public string FooterBoxIcon2 { get; set; }

        [Display(Name = "عنوان فوتر باکس سوم")]
        public string FooterBoxTitle3 { get; set; }
        [Display(Name = "متن فوتر باکس سوم")]
        public string FooterBoxText3 { get; set; }
        [Display(Name = "آیکون فوتر باکس سوم")]
        public string FooterBoxIcon3 { get; set; }

        [Display(Name = "عنوان فوتر باکس چهارم")]
        public string FooterBoxTitle4 { get; set; }
        [Display(Name = "متن فوتر باکس چهارم")]
        public string FooterBoxText4 { get; set; }
        [Display(Name = "آیکون فوتر باکس چهارم")]
        public string FooterBoxIcon4 { get; set; }

        [Display(Name = "عنوان فوتر باکس پنجم")]
        public string FooterBoxTitle5 { get; set; }
        [Display(Name = "متن فوتر باکس پنجم")]
        public string FooterBoxText5 { get; set; }
        [Display(Name = "آیکون فوتر باکس پنجم")]
        public string FooterBoxIcon5 { get; set; }
    }
}