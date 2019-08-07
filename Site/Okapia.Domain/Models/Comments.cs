using System;

namespace Okapia.Domain.Models
{
    public class Comment
    {
        public long CommentId { get; set; }
        public string CommentOwner { get; set; }
        public long CommentOwnerRecordId { get; set; }
        public long CommentatorAccountId { get; set; }
        public string CommentTitle { get; set; }
        public string CommnetText { get; set; }
        public int CommentAgrreCount { get; set; }
        public int CommentDisagreeCount { get; set; }
        public bool CommentIsConfirmed { get; set; }
        public long CommentConfirmingAccountId { get; set; }
        public DateTime CommentConfirmDate { get; set; }
        public bool CommentIsDeleted { get; set; }
        public DateTime CommentCreationDateDate { get; set; }
    }
}