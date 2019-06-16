using System;
using System.ComponentModel.DataAnnotations;

namespace Okapia.Models
{
    public class Login
    {
        [Required]
        [StringLength(10)]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "کلمه رمز")]
        public string Password { get; set; }
    }
}
