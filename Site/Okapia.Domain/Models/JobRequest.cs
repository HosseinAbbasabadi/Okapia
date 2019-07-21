using System;

namespace Okapia.Domain.Models
{
    public class JobRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Tel { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public long TrackingNumber { get; set; }
        public string OperationDescription { get; set; }
        public DateTime CreationDate { get; set; }
    }
}