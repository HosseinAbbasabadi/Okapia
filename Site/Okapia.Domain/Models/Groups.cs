using System;
using System.Collections.Generic;

namespace Okapia.Domain
{
    public partial class Groups
    {
        public Groups()
        {
            Modals = new HashSet<Modals>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public DateTime GroupCreationDate { get; set; }

        public virtual ICollection<Modals> Modals { get; set; }
    }
}