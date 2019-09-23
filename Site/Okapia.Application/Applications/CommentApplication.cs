using System;
using System.Collections.Generic;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Comment;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Comment;

namespace Okapia.Application.Applications
{
    public class CommentApplication : ICommentApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository, IAuthHelper authHelper)
        {
            _commentRepository = commentRepository;
            _authHelper = authHelper;
        }

        public OperationResult Create(AddComment command)
        {
            var result = new OperationResult("Comments", "Create");
            try
            {
                var commentatorAccountId = _authHelper.GetCurrnetUserInfo().AuthUserId;
                var comment = new Comment
                {
                    CommentIsConfirmed = false,
                    CommentIsDeleted = false,
                    CommentatorAccountId = commentatorAccountId,
                    CommentOwnerRecordId = command.CommentOwnerRecordId,
                    CommentOwner = command.CommentOwner,
                    CommentAgreeCount = 0,
                    CommentDisagreeCount = 0,
                    CommnetText = command.CommentText,
                    CommentCreationDate = DateTime.Now,
                    CommentConfirmDate = DateTime.Now
                };
                _commentRepository.Create(comment);
                _commentRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public OperationResult Delete(long id)
        {
            var result = new OperationResult("Comments", "Delete");
            try
            {
                if (!_commentRepository.Exists(x => x.CommentId == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var comment = _commentRepository.Get(id);
                comment.CommentIsDeleted = true;
                _commentRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public OperationResult Activate(long id)
        {
            var result = new OperationResult("Comments", "Activate");
            try
            {
                if (!_commentRepository.Exists(x => x.CommentId == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var comment = _commentRepository.Get(id);
                comment.CommentIsDeleted = false;
                _commentRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public OperationResult Confirm(long id)
        {
            var result = new OperationResult("Comments", "Confirm");
            try
            {
                if (!_commentRepository.Exists(x => x.CommentId == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var comment = _commentRepository.Get(id);
                comment.CommentIsConfirmed = true;
                comment.CommentConfirmDate = DateTime.Now;
                comment.CommentConfirmorAccountId = _authHelper.GetCurrnetUserInfo().AuthUserId;
                _commentRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel, out int recordCount)
        {
            return _commentRepository.Search(searchModel, out recordCount);
        }
    }
}