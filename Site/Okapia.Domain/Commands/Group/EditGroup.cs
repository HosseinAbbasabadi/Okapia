using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Group
{
    public class EditGroup: CreateGroup
    {
        public int Id { get; set; }
        [Display(Name = "آیا حذف شود؟")]
        public bool IsDeleted { get; set; }
    }
}
