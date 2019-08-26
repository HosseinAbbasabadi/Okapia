using System;

namespace Okapia.Domain.Models
{
    public class Link
    {
        public int LinkId { get; set; }
        public string LinkLabel { get; set; }
        public string LinkTarget { get; set; }
        public int LinkCategory { get; set; }
        public bool LinkIsDeleted { get; set; }
        public DateTime LinkCreationDate { get; set; }
    }
}
