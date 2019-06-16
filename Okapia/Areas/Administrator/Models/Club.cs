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

        public List<Okapia.Models.Customer> Customers { get; set; }
    }
}
