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
        private string _card7;
        private string _card8;
        private string _card9;
        private string _card10;

        [Display(Name = "نام فارسی")]
        [RegularExpression(@"^[\u0600-\u06FF|^ ]+$", ErrorMessage = ValidationMessages.PersianText)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی فارسی")]
        [RegularExpression(@"^[\u0600-\u06FF|^ ]+$", ErrorMessage = ValidationMessages.PersianText)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string Family { get; set; }

        [Display(Name = "نام انگلیسی")]
        [RegularExpression(@"^[A-Za-z|^ ]+$", ErrorMessage = ValidationMessages.EnghlishText)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string NameEn { get; set; }

        [Display(Name = "نام خانوادگی انگلیسی")]
        [RegularExpression(@"^[A-Za-z|^ ]+$", ErrorMessage = ValidationMessages.EnghlishText)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string FamilyEn { get; set; }

        [Display(Name = "کد ملی")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = ValidationMessages.NationalCodeStringLength)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string NationalCardNumber { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
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
        [StringLength(19, MinimumLength = 19, ErrorMessage = ValidationMessages.CardStringLength)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [RegularExpression("([0-9]|^-+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card1
        {
            get => _card1;
            set => _card1 = value.ToEnglishNumber();
        }

        [Display(Name = "شماره کارت دوم")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card2
        {
            get => _card2;
            set => _card2 = value.ToEnglishNumber();
        }

        [Display(Name = "شماره کارت سوم")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card3
        {
            get => _card3;
            set => _card3 = value.ToEnglishNumber();
        }

        [Display(Name = "شماره کارت چهارم")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card4
        {
            get => _card4;
            set => _card4 = value.ToEnglishNumber();
        }

        [Display(Name = "شماره کارت پنچم")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card5
        {
            get => _card5;
            set => _card5 = value.ToEnglishNumber();
        }

        [Display(Name = "شماره کارت ششم")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card6
        {
            get => _card6;
            set => _card6 = value.ToEnglishNumber();
        }

        [Display(Name = "شماره کارت هفتم")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card7
        {
            get => _card7;
            set => _card7 = value.ToEnglishNumber();
        }

        [Display(Name = "شماره کارت هشتم")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card8
        {
            get => _card8;
            set => _card8 = value.ToEnglishNumber();
        }

        [Display(Name = "شماره کارت نهم")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card9
        {
            get => _card9;
            set => _card9 = value.ToEnglishNumber();
        }

        [Display(Name = "شماره کارت دهم")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = ValidationMessages.CardStringLength)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Card10
        {
            get => _card10;
            set => _card10 = value.ToEnglishNumber();
        }

        public SelectList Provinces { get; set; }
    }
}