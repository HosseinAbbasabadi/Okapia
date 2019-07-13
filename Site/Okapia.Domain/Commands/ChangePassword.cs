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
        public string NewPassword { get; set; }

        [Display(Name = "تکرار کلمه رمز جدید")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string RepeatNewPassword { get; set; }

        public long ReferenceRecordId { get; set; }
        public int RoleId { get; set; }
    }
}