using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Domain.Commands.District;

namespace Okapia.Domain.Commands.Neighborhood
{
    public class CreateNeighborhood : CreateDistrict
    {
        [Display(Name = "منطقه")]
        public int DistrictId { get; set; }
        public SelectList Districts { get; set; }
    }
}