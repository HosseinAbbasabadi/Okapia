using System;
using System.Collections.Generic;

namespace Okapia.Domain.Models
{
    public sealed class Group
    {
        public Group()
        {
            Modals = new HashSet<Modal>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime GroupCreationDate { get; set; }

        public ICollection<Modal> Modals { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
    }
}