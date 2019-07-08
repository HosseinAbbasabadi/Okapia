using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.User
{
    public class Login
    {
        [StringLength(10)]
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Username { get; set; }

        [StringLength(12)]
        [Display(Name = "کلمه رمز")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Password { get; set; }
    }
}
