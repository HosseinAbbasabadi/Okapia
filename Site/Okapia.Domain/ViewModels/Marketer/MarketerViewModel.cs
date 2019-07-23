using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.Marketer
{
    public class MarketerViewModel
    {
        public long MarketerId { get; set; }
        [Display(Name = "نام کامل")] public string MarketerFullName { get; set; }
        [Display(Name = "کدملی")] public string MarketerNationalCode { get; set; }
        [Display(Name = "موبایل")] public string MarketerMobile { get; set; }

        public int MarketerProvinceId { get; set; }
        [Display(Name = "استان")] public string MarketerProvince { get; set; }

        public int MarketerCityId { get; set; }
        [Display(Name = "شهر")] public string MarketerCity { get; set; }
        public int MarketerDistrictId { get; set; }
        [Display(Name = "منطقه")] public string MarketerDistrict { get; set; }
        public int MarketerNeighborhoodId { get; set; }
        [Display(Name = "محله")] public string MarketerNeighborhood { get; set; }
        public bool MarketerIsDeleted { get; set; }
    }
}