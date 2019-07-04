using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class NeighborhoodSearchModel : DistrictSearchModel
    {
        [Display(Name = "منطقه")]
        public int DistrictId { get; set; }
        public SelectList Districts { get; set; }
    }
}
