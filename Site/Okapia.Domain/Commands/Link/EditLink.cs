using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Link
{
    public class EditLink : CreateLink
    {
        public int Id { get; set; }
        [Display(Name = "آیا حذف شود؟")]
        public bool IsDeleted { get; set; }
    }
}