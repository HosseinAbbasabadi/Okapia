using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands
{
    public class ChangePassword
    {
        //[Display(Name = "کلمه رمز قدیمی")]
        //[Required(ErrorMessage = ValidationMessages.Required)]
        //public string OldPassword { get; set; }

        [Display(Name = "کلمه رمز جدید")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MinLength(6, ErrorMessage = "طول کلمه عبور حداقل ۶ کاراکتر است")]
        public string NewPassword { get; set; }

        [Display(Name = "تکرار کلمه رمز جدید")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MinLength(6, ErrorMessage = "طول کلمه عبور حداقل ۶ کاراکتر است")]
        public string RepeatNewPassword { get; set; }

        public long AccountId { get; set; }
        public int RoleId { get; set; }
    }
}