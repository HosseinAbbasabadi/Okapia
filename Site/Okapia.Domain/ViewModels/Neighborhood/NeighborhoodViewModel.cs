using System.ComponentModel.DataAnnotations;
using Okapia.Domain.ViewModels.District;

namespace Okapia.Domain.ViewModels.Neighborhood
{
    public class NeighborhoodViewModel: DistrictViewModel
    {
        public int DistrictId { get; set; }
        [Display(Name = "منطقه")]
        public string DistrictName { get; set; }
    }
}
