using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.ViewModels.Page;

namespace Okapia.Query.Query
{
    public class PageQuery : BaseViewRepository<long, Page>, IPageQuery
    {
        public PageQuery(OkapiaViewContext context) : base(context)
        {
        }

        public List<PageItemViewModel> GetPagesForLatestArticles()
        {
            return _context.Page.Include(x => x.PageCategory).Include(x => x.PageComments)
                .Where(x => x.PageIsDeleted == false && x.PagePublishDate <= DateTime.Now).Select(
                    page => new PageItemViewModel
                    {
                        PageId = page.PageId,
                        PagePicture = page.PagePicture,
                        PagePictureTitle = page.PagePictureTitle,
                        PagePictureAlt = page.PagePictureAlt,
                        PagePictureDescription = page.PagePictureDescription,
                        PageCategory = page.PageCategory.PageCategoryName,
                        PagePublishDate = page.PagePublishDate.ToFarsi(),
                        PageTittle = page.PageTitle,
                        PageCommentsCount = page.PageComments.Count,
                        PageSmallDescription = page.PageSmallDescription
                    }).OrderByDescending(x => x.PageId).Take(6).ToList();
        }

        public List<PageItemViewModel> GetPagesForBlogBy(int categoryId)
        {
            return _context.Page.Include(x => x.PageCategory).Include(x => x.PageComments)
                .Where(x => x.PageIsDeleted == false).Where(x => x.PagePublishDate >= DateTime.Now)
                .Where(x => x.PageCategoryId == categoryId).Select(
                    page => new PageItemViewModel
                    {
                        PageId = page.PageId,
                        PagePicture = page.PagePicture,
                        PagePictureTitle = page.PagePictureTitle,
                        PagePictureAlt = page.PagePictureAlt,
                        PagePictureDescription = page.PagePictureDescription,
                        PageCategory = page.PageCategory.PageCategoryName,
                        PagePublishDate = page.PagePublishDate.ToFarsi(),
                        PageTittle = page.PageTitle,
                        PageCommentsCount = page.PageComments.Count
                    }).OrderByDescending(x => x.PageId).ToList();
        }
    }
}