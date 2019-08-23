using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.User
{
    public class Login
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Username { get; set; }

        [MinLength(6, ErrorMessage = "طول کلمه عبور حداقل ۶ کاراکتر است")]
        [Display(Name = "کلمه رمز")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Password { get; set; }
    }
}
