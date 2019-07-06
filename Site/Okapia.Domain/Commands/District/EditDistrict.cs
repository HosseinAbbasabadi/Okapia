using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.District
{
    public class EditDistrict : CreateDistrict
    {
        public int Id { get; set; }
        [Display(Name = "استان")]
        public string ProvinceName { get; set; }
        [Display(Name = "شهر")]
        public string CityName { get; set; }
        [Display(Name = "آیا حذف شده است؟")]
        public bool IsDeleted { get; set; }
    }
}