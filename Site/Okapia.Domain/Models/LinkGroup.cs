using System;
using System.Collections.Generic;

namespace Okapia.Domain.Models
{
    public class LinkGroup
    {
        public LinkGroup()
        {
            Links = new List<Link>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatorAccountId { get; set; }
        public ICollection<Link> Links { get; set; }
    }
}