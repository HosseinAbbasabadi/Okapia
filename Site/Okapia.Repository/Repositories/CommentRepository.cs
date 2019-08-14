using System.Collections.Generic;
using System.Linq;
using Framework;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Comment;

namespace Okapia.Repository.Repositories
{
    public class CommentRepository : BaseRepository<long, Comment>, ICommentRepository
    {
        public CommentRepository(OkapiaContext context) : base(context)
        {
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel, out int recordCount)
        {
            var query = _context.Comments.Join(_context.Accounts, x => x.CommentatorAccountId, account => account.Id,
                ((comment, account) => new CommentViewModel
                {
                    CommentId = comment.CommentId,
                    CommentIsConfirmed = comment.CommentIsConfirmed,
                    CommentIsDeleted = comment.CommentIsDeleted,
                    CommentTitle = comment.CommentTitle,
                    CommentOwner = comment.CommentOwner,
                    CommentAgreeCount = comment.CommentAgreeCount,
                    CommentDisagreeCount = comment.CommentDisagreeCount,
                    CommentConfirmDate = comment.CommentConfirmDate.ToFarsi(),
                    CommentCreationDateDate = comment.CommentCreationDate.ToFarsi(),
                    CommentatorUsername = account.Username,
                    CommentText = comment.CommnetText
                }));

            if (!string.IsNullOrEmpty(searchModel.CommentTitle))
                query = query.Where(x => x.CommentTitle.Contains(searchModel.CommentTitle));

            if (searchModel.CommentOwner == "Job")
                query = query.Where(x => x.CommentOwner == "Job");

            if (searchModel.CommentOwner == "Page")
                query = query.Where(x => x.CommentOwner == "Page");

            query = query.Where(x => x.CommentIsConfirmed == searchModel.CommentIsConfirmed);
            query = query.Where(x => x.CommentIsDeleted == searchModel.CommentIsDeleted);

            recordCount = query.Count();

            query = query.OrderByDescending(x => x.CommentId).Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);

            return query.ToList();
        }
    }
}