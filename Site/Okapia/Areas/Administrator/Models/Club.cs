using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Okapia.Areas.Administrator.Models
{
    public class Club
    {
        [Display(Name = "نام باشگاه")]
        public string Name { get; set; }

        [Display(Name = "نام صاحب باشگاه")]
        public string OwnerName { get; set; }

        [Display(Name = "نام خانوادگی صاحب باشگاه")]
        public string OwnerFamily { get; set; }

        [Display(Name = "نام کاربری")]
        public string OwnerUsername { get; set; }

        [Display(Name = "رمز عبور")]
        public string OwnerPassword { get; set; }
        public List<Okapia.Models.Customer> Customers { get; set; }
    }
}
