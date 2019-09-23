using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.LinkGroup
{
    public class EditLinkGroup : CreateLinkGroup
    {
        public int Id { get; set; }
        [Display(Name = "آیا حذف شود؟")] public bool IsDeleted { get; set; }
    }
}