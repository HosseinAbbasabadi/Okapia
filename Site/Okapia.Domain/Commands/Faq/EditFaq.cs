using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Faq
{
    public class EditFaq : CreateFaq
    {
        public long Id { get; set; }
        [Display(Name = "آیا حذف شود؟")]
        public bool IsDeleted { get; set; }
    }
}