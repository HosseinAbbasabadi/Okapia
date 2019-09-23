using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Comment
{
    public class AddComment
    {
        [Display(Name = "عنوان متن")]
        public string CommentText { get; set; }
        public string CommentOwner { get; set; }
        public long CommentOwnerRecordId { get; set; }
        public string CommentOwnerRecordSlug { get; set; }
    }
}
