using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.User
{
    public class CreateUser
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string Family { get; set; }

        [Display(Name = "کد ملی")]
        [StringLength(10, ErrorMessage = ValidationMessages.NationalCodeStringLength)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string NationalCardNumber { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string PhoneNumber { get; set; }

        [Display(Name = "استان")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public int Province { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public int City { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string Address { get; set; }

        [Display(Name = "کد پستی")] public string Postalcode { get; set; }

        [Display(Name = "ایمیل")] public string Email { get; set; }

        [Display(Name = "تاریخ تولد")] public DateTime BirthDate { get; set; }

        [Display(Name = "شماره کارت اول")]
        [StringLength(16, ErrorMessage = ValidationMessages.CardStringLength)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string Card1 { get; set; }

        [Display(Name = "شماره کارت دوم")]
        [StringLength(16, ErrorMessage = ValidationMessages.CardStringLength)]
        public string Card2 { get; set; }

        [Display(Name = "شماره کارت سوم")]
        [StringLength(16, ErrorMessage = ValidationMessages.CardStringLength)]
        public string Card3 { get; set; }

        public SelectList Provinces { get; set; }
    }
}