using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class DistrictSearchModel : CitySearchModel
    {
        [Display(Name = "شهر")]
        public int CityId { get; set; }
        public SelectList Cities { get; set; }
    }
}