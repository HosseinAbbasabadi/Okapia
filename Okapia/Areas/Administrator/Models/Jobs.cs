using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Okapia.Areas.Administrator.Models
{
    public class Jobs
    {
        public Jobs()
        {
            JobPicture = new HashSet<JobPicture>();
            JobRelationJob = new HashSet<JobRelation>();
            JobRelationRelated = new HashSet<JobRelation>();
        }
        
        [Display(Name = "شماره")]
        public int JobId { get; set; }

        [Display(Name = "عنوان")]
        public string JobName { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        public string JobSmallDescription { get; set; }

        [Display(Name = "توضیح کامل")]
        public string JobDescription { get; set; }

        [Display(Name = "نام رابط")]
        public string JobContactTitile { get; set; }

        [Display(Name = "نام مدیر")]
        public string JobManagerFirstName { get; set; }

        [Display(Name = "نام خانوادگی مدیر")]
        public string JobManagerLastName { get; set; }

        [Display(Name = "آدرس ایمیل")]
        public string JobEmailAddress { get; set; }

        [Display(Name = "شماره تلفن ۱")]
        public string JobTel1 { get; set; }

        [Display(Name = "شماره تلفن ۲")]
        public string JobTel2 { get; set; }

        [Display(Name = "شماره موبایل ۱")]
        public string JobMobile1 { get; set; }

        [Display(Name = "شماره موبایل ۲")]
        public string JobMobile2 { get; set; }

        [Display(Name = "استان")]
        public int JobProvienceId { get; set; }

        [Display(Name = "شهر")]
        public int JobCityId { get; set; }

        [Display(Name = "آدرس")]
        public string JobAddress { get; set; }

        [Display(Name = "موقعیت جغرافیایی")]
        public string JobMap { get; set; }

        [Display(Name = "عنوان صفحه شغل")]
        public string JobPageTittle { get; set; }

        [Display(Name = "اسلاگ")]
        public string JobSlug { get; set; }

        [Display(Name = "متاتگ")]
        public string JobMetaTag { get; set; }

        [Display(Name = "توضیحات")]
        public string JobMetaDesccription { get; set; }

        [Display(Name = "اطلاعات هد سثو")]
        public string JobSeohead { get; set; }

        [Display(Name = "آدرس کانونیکال")]
        public string JobCanonicalAddress { get; set; }

        [Display(Name = "شماره قرارداد")]
        public string JobContractNumber { get; set; }

        [Display(Name = "درصد سود معرف")]
        public double? JobBenefitPercentForEndCustomer { get; set; }

        [Display(Name = "درصد سود شرکت")]
        public double? JobBenefitPercentForCompany { get; set; }

        [Display(Name = "آدرس صفحه جایگزین در صورت حذف صفحه")]
        public string JobRemoved301InsteadUrl { get; set; }

        [Display(Name = "درصد تخفیف به مشتری")]
        public double? JobDiscountPercentForCustomer { get; set; }

        [Display(Name = "درصد سود معرف از این شغل")]
        public double? JobBefitPercentForIntroducingEndCustomer { get; set; }

        [Display(Name = "آدرس کانونیکال")]
        public double? MarketerPercentForRegisteringShop { get; set; }

        [Display(Name = "بازاریاب")]
        public int? MarketerId { get; set; }

        [Display(Name = "شماره پوز")]
        public string JobPosNameNumber { get; set; }

        [Display(Name = "شماره حساب صاحب شغل")]
        public string JobAccountNumber { get; set; }

        [Display(Name = "ترتیب نمایش در لیست رده")]
        public int? JobShowOrderIncategory { get; set; }

        [Display(Name = "نمایش در صفحه اصلی")]
        public bool ShowInHomePage { get; set; }

        [Display(Name = "آیا حذف شود")]
        public bool IsDeleted { get; set; }

        [Display(Name = "کارمند ثبت کننده")]
        public int? RegisteringEmployerId { get; set; }

        [Display(Name = "محدودیت در تعداد معرفی اعضا")]
        public int CustomerIntroductionLimit { get; set; }

        [Display(Name = "آیا وبسایت است")]
        public bool IsWebsite { get; set; }

        [Display(Name = "آدرس وبسایت")]
        public string WebsiteUrl { get; set; }

        [Display(Name = "آدرس اینستاگرام")]
        public string InstagramUrl { get; set; }

        [Display(Name = "آدرس تلگرام")]
        public string TelegramUrl { get; set; }
        
        public virtual ICollection<JobPicture> JobPicture { get; set; }
        public virtual ICollection<JobRelation> JobRelationJob { get; set; }
        public virtual ICollection<JobRelation> JobRelationRelated { get; set; }
    }
}