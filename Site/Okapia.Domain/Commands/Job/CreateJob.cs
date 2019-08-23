using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Domain.ViewModels.JobPicture;

namespace Okapia.Domain.Commands.Job
{
    public class CreateJob
    {
        private string _password;
        private string _jobContractNumber;

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string JobName { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string JobSmallDescription { get; set; }

        [Display(Name = "ویژگی های شغل")] public string JobFeatures { get; set; }

        [Display(Name = "توضیح کامل")] public string Content { get; set; }

        [Display(Name = "دسته بندی شغل")]
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.CategoryRange)]
        public int JobCategoryId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [RegularExpression(@"^[A-Za-z0-9|^ ]+$", ErrorMessage = ValidationMessages.EnghlishText)]
        public string Username { get; set; }

        [Display(Name = "کلمه رمز")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Password
        {
            get => _password;
            set => _password = value.ToEnglishNumber();
        }

        [Display(Name = "نام رابط")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string JobContactTitile { get; set; }

        [Display(Name = "نام مدیر")] public string JobManagerFirstName { get; set; }

        [Display(Name = "نام خانوادگی مدیر")] public string JobManagerLastName { get; set; }

        [Display(Name = "آدرس ایمیل")]
        [EmailAddress(ErrorMessage = ValidationMessages.Email)]
        public string JobEmailAddress { get; set; }

        [Display(Name = "شماره تلفن ۱")]
        [MaxLength(11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string JobTel1 { get; set; }

        [Display(Name = "شماره تلفن ۲")]
        [MaxLength(11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string JobTel2 { get; set; }

        [Display(Name = "شماره موبایل ۱")]
        [MaxLength(11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
        [RegularExpression("^09[0-3][0-9]{8}$", ErrorMessage = ValidationMessages.ValidNumber)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string JobMobile1 { get; set; }

        [Display(Name = "شماره موبایل ۲")]
        [MaxLength(11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
        [RegularExpression("^09[0-3][0-9]{8}$", ErrorMessage = ValidationMessages.ValidNumber)]
        public string JobMobile2 { get; set; }

        [Display(Name = "استان")]
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.ProvinceRange)]
        public int JobProvienceId { get; set; }

        [Display(Name = "شهر")]
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.CityRange)]
        public int JobCityId { get; set; }

        [Display(Name = "منطقه")]
        [Range(0, int.MaxValue, ErrorMessage = ValidationMessages.DistrictRange)]
        public int JobDistrictId { get; set; }

        [Display(Name = "محله")]
        [Range(0, int.MaxValue, ErrorMessage = ValidationMessages.NeighborhoodRange)]
        public int JobneighborhoodId { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string JobAddress { get; set; }

        [Display(Name = "نقشه روی Waze")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string JobWazeMap { get; set; }

        [Display(Name = "لینک Waze")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string JobWazeLink { get; set; }

        [Display(Name = "عنوان صفحه شغل(Page Title)")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string JobPageTittle { get; set; }

        [Display(Name = "اسلاگ")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string JobSlug { get; set; }

        [Display(Name = "متاتگ(Meta Tag)")]
        [MaxLength(50, ErrorMessage = "متاتگ نمی تواند بیش از 80 کاراکتر باشد")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string JobMetaTag { get; set; }

        [Display(Name = "توضیحات(Meta Description)")]
        [MaxLength(120, ErrorMessage = "Meta Description نمیتواند بیش از 120 کاراکتر باشد")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string JobMetaDesccription { get; set; }

        [Display(Name = "اطلاعات هد سثو")] public string JobSeohead { get; set; }

        [Display(Name = "آدرس کانونیکال")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        //[Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string JobCanonicalAddress { get; set; }

        [Display(Name = "شماره قرارداد")]
        public string JobContractNumber
        {
            get => _jobContractNumber;
            set => _jobContractNumber = value.ToEnglishNumber();
        }

        [Display(Name = "درصد سود مشتری")]
        [Range(0, 99.99, ErrorMessage = ValidationMessages.ValidNumber)]
        public double JobBenefitPercentForEndCustomer { get; set; }

        [Display(Name = "درصد سود شرکت")]
        [Range(0, 99.99, ErrorMessage = ValidationMessages.ValidNumber)]
        public double JobBenefitPercentForCompany { get; set; }

        [Display(Name = "درصد تخفیف به مشتری")]
        [Range(0, 99.99, ErrorMessage = ValidationMessages.ValidNumber)]
        public double JobDiscountPercentForCustomer { get; set; }

        [Display(Name = "درصد سود معرف از این شغل")]
        [Range(0, 99.99, ErrorMessage = ValidationMessages.ValidNumber)]
        public double JobBefitPercentForIntroducingEndCustomer { get; set; }

        [Display(Name = "درصد سود فروشگاه")]
        [Range(0, 99.99, ErrorMessage = ValidationMessages.ValidNumber)]
        public double MarketerPercentForRegisteringShop { get; set; }

        [Display(Name = "بازاریاب")] public int MarketerId { get; set; }

        [Display(Name = "شماره پوز")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string JobPosNameNumber { get; set; }

        [Display(Name = "شماره حساب صاحب شغل")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string JobAccountNumber { get; set; }

        [Display(Name = "ترتیب نمایش در لیست رده")]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public int JobShowOrderIncategory { get; set; }

        [Display(Name = "نمایش در صفحه اصلی")] public bool ShowInHomePage { get; set; }

        [Display(Name = "محدودیت در تعداد معرفی اعضا")]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public int CustomerIntroductionLimit { get; set; }

        [Display(Name = "آیا وبسایت است")] public bool IsWebsite { get; set; }

        [Url(ErrorMessage = ValidationMessages.Url)]
        [Display(Name = "آدرس وبسایت")]
        public string WebsiteUrl { get; set; }

        [Display(Name = "آدرس اینستاگرام")] public string InstagramUrl { get; set; }

        [Display(Name = "آدرس تلگرام")] public string TelegramUrl { get; set; }


        public int NamePhoto1Id { get; set; }
        public int NamePhoto2Id { get; set; }
        public int NamePhoto3Id { get; set; }
        public int NamePhoto4Id { get; set; }
        public int NamePhoto5Id { get; set; }
        public int NamePhoto6Id { get; set; }

        [Display(Name = "عکس پیشفرش")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string NamePhoto1 { get; set; }

        public string TitlePhoto1 { get; set; }
        public string DescPhoto1 { get; set; }
        public string AltPhoto1 { get; set; }


        [Display(Name = "عکس دوم")] public string NamePhoto2 { get; set; }
        public string TitlePhoto2 { get; set; }
        public string DescPhoto2 { get; set; }
        public string AltPhoto2 { get; set; }
        [Display(Name = "عکس سوم")] public string NamePhoto3 { get; set; }
        public string TitlePhoto3 { get; set; }
        public string DescPhoto3 { get; set; }
        public string AltPhoto3 { get; set; }
        [Display(Name = "عکس چهارم")] public string NamePhoto4 { get; set; }
        public string TitlePhoto4 { get; set; }
        public string DescPhoto4 { get; set; }
        public string AltPhoto4 { get; set; }
        [Display(Name = "عکس پنجم")] public string NamePhoto5 { get; set; }
        public string TitlePhoto5 { get; set; }
        public string DescPhoto5 { get; set; }
        public string AltPhoto5 { get; set; }
        [Display(Name = "عکس ششم")] public string NamePhoto6 { get; set; }
        public string TitlePhoto6 { get; set; }
        public string DescPhoto6 { get; set; }
        public string AltPhoto6 { get; set; }
        public long JobRequestId { get; set; }
        [Display(Name = "نمایش در صفحه اصلی")] public bool IsStared { get; set; }
        public IReadOnlyCollection<JobPictureViewModel> Photos { get; set; }
        public SelectList Proviences { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Marketers { get; set; }
    }
}