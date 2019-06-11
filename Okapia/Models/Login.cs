using System;
using System.ComponentModel.DataAnnotations;

namespace Okapia.Models
{
    public class Login
    {
        [Required]
        [StringLength(10)]
        public string Username { get; set; }

        [Required]
        [StringLength(11)]
        public string Password { get; set; }
    }
}
