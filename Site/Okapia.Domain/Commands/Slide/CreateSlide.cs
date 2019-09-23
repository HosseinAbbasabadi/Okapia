using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.Slide
{
    public class CreateSlide
    {
        [Display(Name = "لینک")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string SlideLink { get; set; }

        [Display(Name = "عکس")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string NameImage { get; set; }

        [Display(Name = "Alt")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string AltImage { get; set; }

        [Display(Name = "Title")] public string TitleImage { get; set; }
        [Display(Name = "Description")] public string DescImage { get; set; }
        [Display(Name = "استان")] public int SlideProvinceId { get; set; }
        public SelectList Provinces { get; set; }
    }
}