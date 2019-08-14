using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Comment
{
    public class AddComment
    {
        [Display(Name = "عنوان نظر")]
        public string CommentTitle { get; set; }
        [Display(Name = "عنوان متن")]
        public string CommentText { get; set; }
        public string CommentOwner { get; set; }
        public long CommentOwnerRecordId { get; set; }
    }
}
