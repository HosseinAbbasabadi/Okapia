using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Comment;

namespace Okapia.Areas.Administrator.Models
{
    public class CommentIndexViewModel
    {
        public CommentSearchModel CommentSearchModel { get; set; }
        public List<CommentViewModel> CommentViewModels { get; set; }

    }
}
