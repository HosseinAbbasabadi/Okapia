using System;
using System.Collections.Generic;

namespace Okapia.Domain
{
    public partial class PageComments
    {
        public int PageCommentId { get; set; }
        public int PageId { get; set; }
        public int? CommentUserId { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentTitle { get; set; }
        public string CommnetText { get; set; }
        public bool? IsConfirmedByAdminiStrator { get; set; }
        public int CommentAgrreCount { get; set; }
        public int CommentDisAgreeCount { get; set; }
        public string CommentPageUrl { get; set; }
        public int? PageCommentConfiringUserId { get; set; }
        public DateTime? PageCommentConfirmDate { get; set; }

        public virtual Page Page { get; set; }
    }
}