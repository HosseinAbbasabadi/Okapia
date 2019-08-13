using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Slide
{
    public class CreateSlide
    {
        [MaxLength(50)]
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string SlideTitleText { get; set; }

        [Display(Name = "توضیح کوتاه")]
        [MaxLength(100)]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string SlideDescriptionText { get; set; }

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
    }
}