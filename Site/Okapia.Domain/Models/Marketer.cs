using System;

namespace Okapia.Domain.Models
{
    public class Marketer
    {
        public long MarketerId { get; set; }
        public string MarketerFirstName { get; set; }
        public string MarketerLastName { get; set; }
        public string MarketerNationalCode { get; set; }
        public string MarketerMobile { get; set; }
        public int MarketerProvinceId { get; set; }
        public int MarketerCityId { get; set; }
        public int MarketerDistrictId { get; set; }
        public int MarketerNeighborhoodId { get; set; }
        public bool MarketerIsDeleted { get; set; }
        public DateTime MarketerCreationDate { get; set; }
        public long MarketerCreatorEmployeeId { get; set; }
    }
}