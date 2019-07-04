using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Neighborhood;

namespace Okapia.Areas.Administrator.Models
{
    public class NeighborhoodIndexViewModel
    {
        public NeighborhoodSearchModel NeighborhoodSearchModel { get; set; }
        public List<NeighborhoodViewModel> NeighborhoodViewModels { get; set; }
    }
}
