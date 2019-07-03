using Okapia.Domain.Commands.Job;

namespace Okapia.Areas.Administrator.Models
{
    public class JobRelation
    {
        public int JobRelationId { get; set; }
        public int JobId { get; set; }
        public int RelatedId { get; set; }

        public virtual CreateJob CreateJob { get; set; }
        public virtual CreateJob Related { get; set; }
    }
}