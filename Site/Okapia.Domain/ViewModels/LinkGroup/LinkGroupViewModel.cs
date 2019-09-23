using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.LinkGroup
{
    public class LinkGroupViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام")] public string Name { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "تاریخ ایجاد")] public string CreationDate { get; set; }
        [Display(Name = "کاربر ایجاد کننده")] public string CreatorUsername { get; set; }
    }
}