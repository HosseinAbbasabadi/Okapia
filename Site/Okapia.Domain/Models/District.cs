using System.Collections.Generic;

namespace Okapia.Domain.Models
{
    public class District
    {
        public District()
        {
            Neighborhood = new HashSet<Neighborhood>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Neighborhood> Neighborhood { get; set; }
    }
}