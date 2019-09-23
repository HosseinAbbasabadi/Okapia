using System;

namespace Okapia.Domain.Models
{
    public class Faq
    {
        public long Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public long JobId { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatorAccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public Job Job { get; set; }
    }
}