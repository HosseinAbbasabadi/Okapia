using System;
using System.ComponentModel.DataAnnotations;
using Framework;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.User
{
    public class CreateUser
    {
        private string _postalcode;
        private string _card1;
        private string _card2;
        private string _card3;
        private string _card4;
        private string _card5;
        private string _card6;

        [Display(Name = "نام")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string Family { get; set; }

        [Display(Name = "کد ملی")]
        [StringLength(10, ErrorMessage = ValidationMessages.NationalCodeStringLength)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string NationalCardNumber { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [MaxLength(11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "استان")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public int ProvinceId { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public int CityId { get; set; }

        [Display(Name = "منطقه")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public int DistrictId { get; set; }

        [Display(Name = "محله")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public int NeighborhoodId { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string Address { get; set; }

        [Display(Name = "کد پستی")]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Postalcode
        {
            get => _postalcode;
            set => _postalcode = value.ToEnglishNumber();
        }

        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = ValidationMessages.Email)]
        public string Email { get; set; }

        [Display(Name = "تاریخ تولد")] public string BirthDate { get; set; }

        public DateTime BirthDateG { get; set; }

        [Display(Name = "شماره کارت اول")]
        [MaxLength(16, ErrorMessage = ValidationMessages.CardStringLength)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card1
        {
            get => _card1;
            set => _card1 = value.ToEnglishNumber();
        }

        [Display(Name = "شماره کارت دوم")]
        [MaxLength(16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card2
        {
            get => _card2;
            set => _card2 = value.ToEnglishNumber();
        }

        [Display(Name = "شماره کارت سوم")]
        [MaxLength(16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card3
        {
            get => _card3;
            set => _card3 = value.ToEnglishNumber();
        }

        [Display(Name = "شماره کارت چهارم")]
        [MaxLength(16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card4
        {
            get => _card4;
            set => _card4 = value.ToEnglishNumber();
        }

        [Display(Name = "شماره کارت پنچم")]
        [MaxLength(16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card5
        {
            get => _card5;
            set => _card5 = value.ToEnglishNumber();
        }

        [Display(Name = "شماره کارت ششم")]
        [MaxLength(16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card6
        {
            get => _card6;
            set => _card6 = value.ToEnglishNumber();
        }

        public SelectList Provinces { get; set; }
    }
}