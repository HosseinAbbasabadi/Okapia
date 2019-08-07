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
        [StringLength(10, MinimumLength = 10, ErrorMessage = ValidationMessages.NationalCodeStringLength)]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string MarketerNationalCode { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
        [RegularExpression("^09[0-3][0-9]{8}$", ErrorMessage = ValidationMessages.ValidNumber)]
        public string MarketerMobile { get; set; }

        [Display(Name = "استان")]
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.ProvinceRange)]
        public int MarketerProvinceId { get; set; }

        [Display(Name = "شهر")]
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.CityRange)]
        public int MarketerCityId { get; set; }

        [Display(Name = "منطقه")]
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.DistrictRange)]
        public int MarketerDistrictId { get; set; }

        [Display(Name = "محله")]
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.NeighborhoodRange)]
        public int MarketerNeighborhoodId { get; set; }

        public SelectList Provinces { get; set; }
    }
}