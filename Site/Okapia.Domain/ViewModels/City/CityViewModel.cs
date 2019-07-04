using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.City
{
    public class CityViewModel : PlaceViewModel
    {
        [Display(Name = "استان")]
        public int ProvinceId { get; set; }
        [Display(Name = "استان")]
        public string ProvinceName { get; set; }
    }
}