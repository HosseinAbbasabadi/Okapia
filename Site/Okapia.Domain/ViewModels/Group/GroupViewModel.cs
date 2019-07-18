using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.Group
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "حذف شده")]
        public bool IsDeleted { get; set; }
    }
}
