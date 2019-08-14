using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Comment;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Comment;

namespace Okapia.Application.Contracts
{
    public interface ICommentApplication
    {
        OperationResult Create(AddComment command);
        OperationResult Delete(long id);
        OperationResult Activate(long id);
        OperationResult Confirm(long id);
        List<CommentViewModel> Search(CommentSearchModel searchModel, out int recordCount);
    }
}
