using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.City
{
    public class CreateCity
    {
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "استان")]
        public int ProvinceId { get; set; }
        public SelectList Provinces { get; set; }
    }
}
