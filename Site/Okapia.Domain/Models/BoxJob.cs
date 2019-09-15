namespace Okapia.Domain.Models
{
    public class BoxJob
    {
        public int BoxId { get; set; }
        public Box Box { get; set; }
        public long JobId { get; set; }
        public Job Job { get; set; }
    }
}
