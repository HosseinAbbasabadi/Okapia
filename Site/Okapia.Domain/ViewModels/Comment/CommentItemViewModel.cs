using System;

namespace Okapia.Domain.ViewModels.Comment
{
    public class CommentItemViewModel
    {
        public string CommentorFullname { get; set; }
        public string CommentTitle { get; set; }
        public string CommentText { get; set; }
        public int CommentAgreeCount { get; set; }
        public int CommentDisagreeCount { get; set; }
        public string CommentCreationDate { get; set; }
    }
}