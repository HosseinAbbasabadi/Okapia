using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Contactus
{
    public class CreateContact
    {
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Email { get; set; }

        public string Message { get; set; }
    }
}