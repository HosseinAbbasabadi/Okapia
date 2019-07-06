using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Domain.Commands.District;

namespace Okapia.Domain.Commands.Neighborhood
{
    public class CreateNeighborhood : CreateDistrict
    {
        [Display(Name = "منطقه")]
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.DistrictRange)]
        public int DistrictId { get; set; }
        public SelectList Districts { get; set; }
    }
}