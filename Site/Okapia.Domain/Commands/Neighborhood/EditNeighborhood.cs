using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Neighborhood
{
    public class EditNeighborhood : CreateNeighborhood
    {
        public int Id { get; set; }
        [Display(Name = "استان")]
        public string ProvinceName { get; set; }
        [Display(Name = "شهر")]
        public string CityName { get; set; }
        [Display(Name = "منطقه")]
        public string DistrictName { get; set; }
        [Display(Name = "آیا حذف شده است؟")]
        public bool IsDeleted { get; set; }
    }
}
