using System;
using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.Comment
{
    public class CommentViewModel
    {
        public long CommentId { get; set; }
        [Display(Name = "بخش مربوطه")]
        public string CommentOwner { get; set; }
        [Display(Name = "ارسال کننده")]
        public string CommentatorUsername { get; set; }
        [Display(Name = "متن")]
        public string CommentText { get; set; }
        [Display(Name = "رای مثبت")]
        public int CommentAgreeCount { get; set; }
        [Display(Name = "رای منفی")]
        public int CommentDisagreeCount { get; set; }
        [Display(Name = "وضعیت تایید")]
        public bool CommentIsConfirmed { get; set; }
        [Display(Name = "تاریخ تایید")]
        public string CommentConfirmDate { get; set; }
        public DateTime CommentConfirmDateG { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public string CommentCreationDateDate { get; set; }
        public DateTime CommentCreationDateDateG { get; set; }
        public bool CommentIsDeleted { get; set; }
    }
}
