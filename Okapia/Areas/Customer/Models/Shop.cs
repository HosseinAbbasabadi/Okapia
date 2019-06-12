using System.ComponentModel.DataAnnotations;

namespace Okapia.Areas.Customer.Models
{
    public class Shop
    {
        [Display(Name = "نام فروشگاه")]
        public string Name { get; set; }

        [Display(Name = "گروه")]
        public string Category { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; }

        [Display(Name = "قیمت یک واحد خدمات")]
        public decimal Price { get; set; }

        [Display(Name = "درصد سود")]
        public decimal InterestRates { get; set; }
    }
}
