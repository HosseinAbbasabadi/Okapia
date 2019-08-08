using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Comment;

namespace Okapia.Application.Contracts
{
    public interface ICommentApplication
    {
        List<CommentViewModel> Search(CommentSearchModel searchModel, out int recordCount);
    }
}
