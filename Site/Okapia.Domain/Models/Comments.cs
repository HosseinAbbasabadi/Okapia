using System;

namespace Okapia.Domain.Models
{
    public class Comment
    {
        public long CommentId { get; set; }
        public string CommentOwner { get; set; }
        public long CommentOwnerRecordId { get; set; }
        public long CommentatorAccountId { get; set; }
        public string CommnetText { get; set; }
        public int CommentAgreeCount { get; set; }
        public int CommentDisagreeCount { get; set; }
        public bool CommentIsConfirmed { get; set; }
        public long CommentConfirmorAccountId { get; set; }
        public DateTime CommentConfirmDate { get; set; }
        public DateTime CommentCreationDate { get; set; }
        public bool CommentIsDeleted { get; set; }
        
        public Page Page { get; set; }
        public Job Job { get; set; }
    }
}