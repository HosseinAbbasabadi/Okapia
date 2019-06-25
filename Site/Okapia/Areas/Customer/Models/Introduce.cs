using System.ComponentModel.DataAnnotations;

namespace Okapia.Areas.Customer.Models
{
    public class Introduce
    {
        [MaxLength(10)]
        [Display(Name = "شماره ملی")]
        public string NationalCode { get; set; }

        [MaxLength(11)]
        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; }

        [MaxLength(5)]
        [Display(Name = "کد پنج رقمی رسید خرید")]
        public string Code { get; set; }
    }
}
