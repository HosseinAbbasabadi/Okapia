using System.ComponentModel.DataAnnotations;
using Okapia.Domain;

namespace Okapia.Models
{
    public class ChooseFpMethod
    {
        [Display(Name = "شماره موبایل")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
        [RegularExpression("^09[0-3][0-9]{8}$", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Phonenumber { get; set; }

        [Display(Name = "آدرس ایمیل")]
        [EmailAddress(ErrorMessage = ValidationMessages.Email)]
        public string Email { get; set; }

        public string Type { get; set; }

        [Display(Name = "کد")]
        //[MaxLength(5, ErrorMessage = "کد احراز هویت ۵ رقمی است")]
        //[MinLength(5, ErrorMessage = "کد احراز هویت ۵ رقمی است")]
        public long Code { get; set; }

    }
}