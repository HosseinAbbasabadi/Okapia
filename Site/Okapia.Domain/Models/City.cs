﻿using System.Collections.Generic;

namespace Okapia.Domain.Models
{
    public partial class City
    {
        public City()
        {
            District = new HashSet<District>();
        }

        public int Id { get; set; }
        public int? ProvinceId { get; set; }
        public string Name { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<District> District { get; set; }
    }
}