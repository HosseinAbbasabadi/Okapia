namespace Okapia.Domain.Models
{
    public class Neighborhood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual District District { get; set; }
    }
}