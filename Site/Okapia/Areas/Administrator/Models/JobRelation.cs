﻿namespace Okapia.Areas.Administrator.Models
{
    public class JobRelation
    {
        public int JobRelationId { get; set; }
        public int JobId { get; set; }
        public int RelatedId { get; set; }

        public virtual Jobs Job { get; set; }
        public virtual Jobs Related { get; set; }
    }
}