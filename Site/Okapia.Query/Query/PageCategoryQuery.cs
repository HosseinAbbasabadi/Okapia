using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.ViewModels.Page;
using Okapia.Domain.ViewModels.PageCategory;

namespace Okapia.Query.Query
{
    public class PageCategoryQuery : BaseViewRepository<int, PageCategory>, IPageCategoryQuery
    {
        public PageCategoryQuery(OkapiaViewContext context) : base(context)
        {
        }

        public List<PageCategoryItemViewModel> GetPageCategoriesForFooter()
        {
            return _context.PageCategory.Where(x => x.PageCategoryIsDeleted == false && x.PageCategoryParentId == 0)
                .Select(x => new PageCategoryItemViewModel
                {
                    PageCategoryId = x.PageCategoryId,
                    PageCategorySlug = x.PageCategorySlug,
                    PageCategoryName = x.PageCategoryName,
                    //PageCategoryMetaDesccription = x.PageCategoryMetaDesccription,
                    //PageCategoryMetaTag = x.PageCategoryMetaTag,
                    //PageCategoryPageTitle = x.PageCategoryPageTitle,
                    //PageCategorySeohead = x.PageCategorySeohead,
                    //PageCategoryShowOrder = x.PageCategoryShowOrder
                }).OrderByDescending(x => x.PageCategoryShowOrder).ToList();
        }

        public PageCategoryBlogViewModel GetPageCategoryForBlog(string categorySlug)
        {
            if (categorySlug == "همه")
            {
                var pageCategory = new PageCategoryBlogViewModel
                {
                    MetaTags = new List<string> {"", "", ""},
                    PageCategoryMetaDescription = "",
                    PageCategorySlug = "همه",
                    PageCategoryName = "همه",
                    PageCategoryMetaTags = ""                    
                };

                pageCategory.Pages = _context.Page.Where(x => x.PageIsDeleted == false).Select(page =>
                    new PageItemViewModel
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
                        PageSmallDescription = page.PageSmallDescription
                    }).ToList();
                return pageCategory;
            }
            else
            {
                var pageCategory = _context.PageCategory.Include(x => x.Pages)
                    .Where(x => x.PageCategoryIsDeleted == false)
                    .FirstOrDefault(x => x.PageCategorySlug == categorySlug);
                if (pageCategory == null) return new PageCategoryBlogViewModel();
                var getPagesForBlog = new PageCategoryBlogViewModel
                {
                    PageCategoryId = pageCategory.PageCategoryId,
                    PageCategoryMetaTags = pageCategory.PageCategoryMetaTag,
                    PageCategoryMetaDescription = pageCategory.PageCategoryMetaDesccription,
                    PageCategoryCanonicalAddress = pageCategory.PageCanonicalAddress,
                    PageCategorySlug = pageCategory.PageCategorySlug,
                    PageCategoryName = pageCategory.PageCategoryName,
                    MetaTags = pageCategory.PageCategoryMetaTag.Split(",").ToList(),
                    Pages = MapPages(pageCategory.Pages.ToList())
                };
                return getPagesForBlog;
            }
        }

        private static List<PageItemViewModel> MapPages(List<Page> pages)
        {
            var result = new List<PageItemViewModel>();
            pages.ForEach(page =>
            {
                var commentsCount = 0;
                if (page.PageComments != null)
                    commentsCount = page.PageComments.Count;
                var pageItem = new PageItemViewModel
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
                    PageCommentsCount = commentsCount,
                    PageSmallDescription = page.PageSmallDescription
                };
                result.Add(pageItem);
            });
            return result;
        }
    }
}