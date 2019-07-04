using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.District;

namespace Okapia.Areas.Administrator.Models
{
    public class DistrictIndexViewModel
    {
        public DistrictSearchModel DistrictSearchModel { get; set; }
        public IEnumerable<DistrictViewModel> DistrictIndexViewModels { get; set; }
    }
}
