using System.ComponentModel.DataAnnotations;

namespace Okapia.Models
{
    public class Agency
    {
        [Display(Name = "نام فروشگاه")]
        public string Name { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; }

        [Display(Name = "توضیحات تکمیلی")]
        public string Description { get; set; }
    }
}
