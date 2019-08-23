using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.ViewModels.Comment;
using Okapia.Domain.ViewModels.Page;

namespace Okapia.Query.Query
{
    public class PageQuery : BaseViewRepository<long, Page>, IPageQuery
    {
        private readonly IAccountRepository _accountRepository;

        public PageQuery(OkapiaViewContext context, IAccountRepository accountRepository) : base(context)
        {
            _accountRepository = accountRepository;
        }

        public List<PageItemViewModel> GetPagesForLatestArticles()
        {
            return _context.Page.Include(x => x.PageCategory).Include(x => x.PageComments)
                .Where(x => x.PageIsDeleted == false && x.PagePublishDate <= DateTime.Now).Select(
                    page => new PageItemViewModel
                    {
                        PageId = page.PageId,
                        PageSlug = page.PageSlug,
                        PagePicture = page.PagePicture,
                        PagePictureTitle = page.PagePictureTitle,
                        PagePictureAlt = page.PagePictureAlt,
                        PagePictureDescription = page.PagePictureDescription,
                        PageCategory = page.PageCategory.PageCategoryName,
                        PagePublishDate = page.PagePublishDate.ToFarsi(),
                        PageTitle = page.PageTitle,
                        PageCommentsCount = page.PageComments.Count,
                        PageSmallDescription = page.PageSmallDescription
                    }).OrderByDescending(x => x.PageId).Take(6).ToList();
        }


        public PageViewDetailsViewModel GetPageDetailsForView(string slug)
        {
            var pageDetails = _context.Page.Include(x => x.PageCategory).Include(x => x.PageComments)
                .Where(x => x.PagePublishDate <= DateTime.Now)
                .Select(
                    page => new PageViewDetailsViewModel
                    {
                        PageId = page.PageId,
                        PageSlug = page.PageSlug,
                        PagePicture = page.PagePicture,
                        PagePictureTitle = page.PagePictureTitle,
                        PagePictureAlt = page.PagePictureAlt,
                        PagePictureDescription = page.PagePictureDescription,
                        PageCategoryId = page.PageCategoryId,
                        PageCategory = page.PageCategory.PageCategoryName,
                        PagePublishDate = page.PagePublishDate.ToFarsi(),
                        PageTitle = page.PageTitle,
                        PageSmallDescription = page.PageSmallDescription,
                        PageCommentsCount = page.PageComments.Count,
                        PageDescription = page.PageContent,
                        PageMetaDescription = page.PageMetaDesccription,
                        PageMetaTag = page.PageMetaTag,
                        PageCanonicalAddress = page.PageCanonicalAddress,
                    }).FirstOrDefault(x => x.PageSlug == slug);
            if (pageDetails == null) return new PageViewDetailsViewModel();

            pageDetails.MetaTags = pageDetails.PageMetaTag.Split(",").ToList();
            var commentItemViewModels = new List<CommentItemViewModel>();
            var comments = _context.Comments.Where(x =>
                    x.CommentIsConfirmed && !x.CommentIsDeleted && x.CommentOwner == "Page" &&
                    x.CommentOwnerRecordId == pageDetails.PageId)
                .ToList();
            comments.ForEach(c =>
            {
                //var commentator = _userRepository.GetUserBy(c.CommentatorAccountId);
                var commentator = _accountRepository.GetAccount(c.CommentatorAccountId);
                var comment = new CommentItemViewModel
                {
                    //CommentorFullname = commentator.UserFirstName + "" + commentator.UserLastName,
                    CommentorFullname = commentator.Username,
                    CommentTitle = c.CommentTitle,
                    CommentText = c.CommnetText,
                    CommentCreationDate = c.CommentCreationDate.ToFarsi(),
                    CommentAgreeCount = c.CommentAgreeCount,
                    CommentDisagreeCount = c.CommentDisagreeCount
                };
                commentItemViewModels.Add(comment);
            });

            pageDetails.Comments = commentItemViewModels;
            return pageDetails;
        }
    }
}