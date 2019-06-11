using System.ComponentModel.DataAnnotations;

namespace Okapia.Models
{
    public class Customer
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Family { get; set; }

        [Required]
        [StringLength(10)]
        public string NationalCardNumber { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [Required]
        [StringLength(16)]
        public string Card1 { get; set; }

        [StringLength(16)]
        public string Card2 { get; set; }

        [StringLength(16)]
        public string Card3 { get; set; }
    }

}
