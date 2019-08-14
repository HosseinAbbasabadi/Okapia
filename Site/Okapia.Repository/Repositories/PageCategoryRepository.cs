using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.PageCategory;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.PageCategory;

namespace Okapia.Repository.Repositories
{
    public class PageCategoryRepository : BaseRepository<int, PageCategory>, IPageCategoryRepository
    {
        public PageCategoryRepository(OkapiaContext context) : base(context)
        {
        }

        public EditPageCategory GetPageCategoryDetails(int id)
        {
            return _context.PageCategory.Select(x => new EditPageCategory
            {
                PageCategoryId = x.PageCategoryId,
                PageCategoryName = x.PageCategoryName,
                PageCategoryPageTitle = x.PageCategoryPageTitle,
                PageCategoryIsDeleted = x.PageCategoryIsDeleted,
                PageCanonicalAddress = x.PageCanonicalAddress,
                PageCategoryMetaTag = x.PageCategoryMetaTag,
                AltImage = x.PageCategorySmallPictutreAlt,
                DescImage = x.PageCategorySmallPictutreDescription,
                TitleImage = x.PageCategorySmallPictutreTitle,
                PageCategorySlug = x.PageCategorySlug,
                PageCategoryMetaDesccription = x.PageCategoryMetaDesccription,
                PageCategoryShowOrder = x.PageCategoryShowOrder,
                PageCategoryParentId = x.PageCategoryParentId,
                NameImage = x.PageCategorySmallPictutre,
                PageCategorySeohead = x.PageCategorySeohead,
                PageCategoryRemoved301InsteadUrl = x.PageCategoryRemoved301InsteadUrl
            }).FirstOrDefault(x => x.PageCategoryId == id);
        }

        public List<PageCategoryViewModel> GetPageCategories()
        {
            return _context.PageCategory.Where(x => x.PageCategoryIsDeleted == false).Select(x =>
                new PageCategoryViewModel
                {
                    PageCategoryId = x.PageCategoryId,
                    PageCategoryName = x.PageCategoryName
                }).ToList();
        }

        public List<PageCategoryViewModel> Search(PageCategorySearchModel searchModel, out int recordCount)
        {
            var q = _context.PageCategory.Include(x => x.Pages).AsQueryable();
            var query = from pageCategory in q
                join account in _context.Accounts
                    on pageCategory.PageCategoryRegisteringEmployeId equals account.Id
                select new PageCategoryViewModel
                {
                    PageCategoryId = pageCategory.PageCategoryId,
                    PageCategoryName = pageCategory.PageCategoryName,
                    PageCategoryIsDeleted = pageCategory.PageCategoryIsDeleted,
                    PageCategoryParentId = pageCategory.PageCategoryParentId,
                    //PageCategoryParent = pageCategory.PageCategoryParent.PageCategoryName,
                    PageCategoryRegisteringEmployeId = pageCategory.PageCategoryRegisteringEmployeId,
                    PageCategoryRegisteringEmploye = account.Username,
                    Photo = pageCategory.PageCategorySmallPictutre,
                    PhotoAlt = pageCategory.PageCategorySmallPictutreAlt,
                    PageCount = pageCategory.Pages.Count
                };

            if (!string.IsNullOrEmpty(searchModel.PageCategoryName))
                query = query.Where(x => x.PageCategoryName.Contains(searchModel.PageCategoryName));
            if (searchModel.PageCategoryParentId != 0)
                query = query.Where(x => x.PageCategoryParentId == searchModel.PageCategoryParentId);
            if (searchModel.PageCategoryRegisteringEmployeId != 0)
                query = query.Where(x =>
                    x.PageCategoryRegisteringEmployeId == searchModel.PageCategoryRegisteringEmployeId);
            query = query.Where(x => x.PageCategoryIsDeleted == searchModel.PageCategoryIsDeleted);
            recordCount = query.Count();
            query = query.OrderByDescending(x => x.PageCategoryId).Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);
            return query.ToList();
        }
    }
}