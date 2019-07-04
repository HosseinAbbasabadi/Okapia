using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.City
{
    public class PlaceViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "آیا حذف شده است؟")]
        public bool IsDeleted { get; set; }
    }
}
