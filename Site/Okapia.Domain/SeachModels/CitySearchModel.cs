using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class CitySearchModel : BaseSerachModel
    {
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public bool IsDeleted { get; set; }
        public SelectList Provinces { get; set; }
    }
}
