using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.City
{
    public class EditCity: CreateCity
    {
        public int Id { get; set; }
        public string ProvinceName { get; set; }
        [Display(Name = "آیا حذف شود؟")]
        public bool IsDeleted { get; set; }
    }
}
