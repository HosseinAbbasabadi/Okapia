using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Domain.Commands.City;

namespace Okapia.Domain.Commands.District
{
    public class CreateDistrict : CreateCity
    {
        [Display(Name = "شهر")]
        public int CityId { get; set; }
        public SelectList Cities { get; set; }
    }
}