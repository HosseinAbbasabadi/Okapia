using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.Faq
{
    public class CreateFaq
    {
        [Display(Name = "پرسش")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Question { get; set; }
        [Display(Name = "پاسخ")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Answer { get; set; }
        [Display(Name = "شغل مربوطه")]
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.Required)]
        public long JobId { get; set; }
        public SelectList Jobs { get; set; }
    }
}