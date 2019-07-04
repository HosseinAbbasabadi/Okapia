using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.City;

namespace Okapia.Areas.Administrator.Models
{
    public class CityIndexViewModel
    {
        public CitySearchModel CitySearchModel { get; set; }
        public IEnumerable<CityViewModel> CityViewModeles { get; set; }
    }
}
