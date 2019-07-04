using System.ComponentModel.DataAnnotations;
using Okapia.Domain.ViewModels.City;

namespace Okapia.Domain.ViewModels.District
{
    public class DistrictViewModel : CityViewModel
    {
        public int CityId { get; set; }
        [Display(Name = "شهر")]
        public string CityName { get; set; }
    }
}
