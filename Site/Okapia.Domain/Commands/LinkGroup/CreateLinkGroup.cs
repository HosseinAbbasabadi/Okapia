using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.LinkGroup
{
    public class CreateLinkGroup
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Name { get; set; }
    }
}