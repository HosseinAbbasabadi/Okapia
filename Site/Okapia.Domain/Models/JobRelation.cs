namespace Okapia.Domain.Models
{
    public class JobRelation
    {
        public int JobRelationId { get; set; }
        public int JobId { get; set; }
        public int RelatedId { get; set; }

        //public virtual Job Job { get; set; }
        //public virtual Job Related { get; set; }
    }
}