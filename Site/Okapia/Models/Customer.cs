using System.ComponentModel.DataAnnotations;

namespace Okapia.Models
{
    public class Customer
    {
        [Required]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "کد ملی")]
        public string NationalCardNumber { get; set; }

        [Required]
        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; }

        [Display(Name = "استان")]
        public string Province { get; set; }

        [Display(Name = "شهر")]
        public string City { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "کد پستی")]
        public string Postalcode { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required]
        [StringLength(16)]
        [Display(Name = "شماره کارت اول")]
        public string Card1 { get; set; }

        [StringLength(16)]
        [Display(Name = "شماره کارت دوم")]
        public string Card2 { get; set; }

        [StringLength(16)]
        [Display(Name = "شماره کارت سوم")]
        public string Card3 { get; set; }
    }

}
