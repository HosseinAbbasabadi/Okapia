using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Modal
{
    public class EditModal : CreateModal
    {
        public int Id { get; set; }
        [Display(Name = "آیا حذف شود؟")] public bool IsDeleted { get; set; }
    }
}