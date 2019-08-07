using System.ComponentModel.DataAnnotations;

namespace Okapia.Areas.Customer.Models
{
    public class IntroduceUser
    {
        [MaxLength(10)]
        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }

        [MaxLength(11)]
        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; }

        [MaxLength(5)]
        [Display(Name = "کد پنج رقمی رسید خرید")]
        public string Code { get; set; }
    }
}
