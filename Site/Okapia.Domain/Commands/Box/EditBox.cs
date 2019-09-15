using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Box
{
    public class EditBox : CreateBox
    {
        public int BoxId { get; set; }

        [Display(Name = "آیا باکس فعال باشد؟")]
        public bool BoxIsEnabled { get; set; }
    }
}