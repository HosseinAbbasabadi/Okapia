using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.JobRequest
{
    public class CreateJobRequest
    {
        [Display(Name = "عنوان شغلی")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Name { get; set; }

        [Display(Name = "نام رابط")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string ContactTitle { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Address { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [MaxLength(11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Mobile { get; set; }

        [Display(Name = "شماره تفلن ثابت")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        [MaxLength(11, ErrorMessage = ValidationMessages.PhoneNumberLenght)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidNumber)]
        public string Tel { get; set; }

        [Display(Name = "توضیحات")] public string Description { get; set; }

        [Display(Name = "استان")]
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.ProvinceRange)]
        public int ProvinceId { get; set; }

        [Display(Name = "شهر")]
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.ProvinceRange)]
        public int CityId { get; set; }

        public SelectList Provinces { get; set; }
    }
}