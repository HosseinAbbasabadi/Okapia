using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.Link
{
    public class CreateLink
    {
        [Display(Name = "نام لینک")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Label { get; set; }

        [Display(Name = "آدرس لینک")]
        [Url(ErrorMessage = ValidationMessages.Url)]
        public string Target { get; set; }

        [Display(Name = "گروه")] public int Group { get; set; }
        public SelectList LinkGroups { get; set; }
    }
}