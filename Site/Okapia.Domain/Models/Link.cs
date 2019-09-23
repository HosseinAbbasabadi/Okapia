using System;
using System.Collections.Generic;

namespace Okapia.Domain.Models
{
    public class Link
    {
        public int LinkId { get; set; }
        public string LinkLabel { get; set; }
        public string LinkTarget { get; set; }
        public int LinkGroupId { get; set; }
        public bool LinkIsDeleted { get; set; }
        public DateTime LinkCreationDate { get; set; }

        public LinkGroup LinkGroup { get; set; }
    }
}
