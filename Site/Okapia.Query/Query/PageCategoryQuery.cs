using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.ViewModels.PageCategory;

namespace Okapia.Query.Query
{
    public class PageCategoryQuery : BaseViewRepository<int, PageCategory>, IPageCategoryQuery
    {
        public PageCategoryQuery(OkapiaViewContext context) : base(context)
        {
        }

        public List<PageCategoryMenuViewModel> GetPageCategoriesForMenu()
        {
            return _context.PageCategory.Where(x => x.PageCategoryIsDeleted == false && x.PageCategoryParentId == 0)
                .OrderByDescending(x => x.PageCategoryShowOrder)
                .Select(x => new PageCategoryMenuViewModel
                {
                    PageCategoryId = x.PageCategoryId,
                    PageCategoryName = x.PageCategoryName,
                    PageCategoryMetaDesccription = x.PageCategoryMetaDesccription,
                    PageCategoryMetaTag = x.PageCategoryMetaTag,
                    PageCategoryPageTitle = x.PageCategoryPageTitle,
                    PageCategorySeohead = x.PageCategorySeohead,
                    PageCategoryShowOrder = x.PageCategoryShowOrder,
                    PageCategorySlug = x.PageCategorySlug
                }).ToList();
        }
    }
}