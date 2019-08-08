using System.Collections.Generic;
using Okapia.Application.Contracts;
using Okapia.Domain.Contracts;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Comment;

namespace Okapia.Application.Applications
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel, out int recordCount)
        {
            return _commentRepository.Search(searchModel, out recordCount);
        }
    }
}