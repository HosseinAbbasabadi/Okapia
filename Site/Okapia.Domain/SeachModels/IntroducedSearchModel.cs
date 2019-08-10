using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.SeachModels
{
    public class IntroducedSearchModel : BaseSerachModel
    {
        [Display(Name = "نام فارسی")] public string FirstNameFa { get; set; }
        [Display(Name = "نام خانوادگی فارسی")] public string LastNameFa { get; set; }
        [Display(Name = "نام انگلیسی")] public string FirstNameEn { get; set; }

        [Display(Name = "نام خانوادگی انگلیسی")]
        public string LastNameEn { get; set; }
        [Display(Name = "کدملی")] public string NationalCode { get; set; }
        [Display(Name = "موبایل")] public string Phonenumber { get; set; }
        public long CurrentUserAccountId { get; set; }
    }
}