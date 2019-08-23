using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Category
{
    public class EditCategory : CreateCategory
    {
        public int CategoryId { get; set; }
        [Display(Name = "آیا حذف شود؟")] public bool IsDeleted { get; set; }
    }
}