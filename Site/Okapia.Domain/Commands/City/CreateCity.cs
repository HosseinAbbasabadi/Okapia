using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.City
{
    public class CreateCity
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = ValidationMessages.Required, AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Display(Name = "استان")]
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.ProvinceRange)]
        public int ProvinceId { get; set; }
        public SelectList Provinces { get; set; }
    }
}