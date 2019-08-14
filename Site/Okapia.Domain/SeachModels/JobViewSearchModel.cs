using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class JobViewSearchModel
    {
        [Display(Name = "گروه")] public int CategoryId { get; set; }
        [Display(Name = "استان")] public int Province { get; set; }
        [Display(Name = "شهر")] public int City { get; set; }
        [Display(Name = "منطقه")] public int District { get; set; }
        [Display(Name = "محله")] public int Neighborhood { get; set; }
        public string Text { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Provinces { get; set; }
        public SelectList Cities { get; set; }
        public SelectList Districts { get; set; }
        public SelectList Neighborhoods { get; set; }
    }
}