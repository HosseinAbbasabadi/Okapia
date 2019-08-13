using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Slide
{
    public class EditSlide : CreateSlide
    {
        public int SlideId { get; set; }
        [Display(Name = "آیا حذف شود؟")] public bool SlideIsDeleted { get; set; }
    }
}