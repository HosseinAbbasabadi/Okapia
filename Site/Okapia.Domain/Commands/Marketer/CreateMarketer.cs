using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.Marketer
{
    public class CreateMarketer
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string MarketerFirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string MarketerLastName { get; set; }

        [Display(Name = "کد ملی")]
        [StringLength(10, ErrorMessage = ValidationMessages.NationalCodeStringLength)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string MarketerNationalCode { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [MaxLength(11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string MarketerMobile { get; set; }

        [Display(Name = "استان")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public int MarketerProvinceId { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]

        public int MarketerCityId { get; set; }

        [Display(Name = "منطقه")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public int MarketerDistrictId { get; set; }

        [Display(Name = "محله")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public int MarketerNeighborhoodId { get; set; }

        public SelectList Provinces { get; set; }
    }
}