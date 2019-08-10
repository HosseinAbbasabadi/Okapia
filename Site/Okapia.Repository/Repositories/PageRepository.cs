using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.Page;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Page;

namespace Okapia.Repository.Repositories
{
    public class PageRepository : BaseRepository<long, Page>, IPageRepository
    {
        public PageRepository(OkapiaContext context) : base(context)
        {
        }

        public EditPage GetPageDetails(long id)
        {
            return _context.Page.Include(x => x.PageCategory).Select(page => new EditPage
            {
                PageId = page.PageId,
                PagePublishDate = page.PagePublishDate.ToFarsi(),
                PageSlug = page.PageSlug,
                PageTitle = page.PageTittle,
                PageIsDeleted = page.PageIsDeleted,
                PageCanonicalAddress = page.PageCanonicalAddress,
                PageSmallDescription = page.PageSmallDescription,
                Content = page.PageContent,
                PageCategoryId = page.PageCategoryId,
                PageMetaDesccription = page.PageMetaDesccription,
                PageMetaTag = page.PageMetaTag,
                PageRemoved301InsteadUrl = page.PageRemoved301InsteadUrl,
                PageSeohead = page.PageSeohead
            }).FirstOrDefault(x => x.PageId == id);
        }

        public List<PageViewModel> Search(PageSearchModel searchModel, out int recordCount)
        {
            var q = _context.Page.Include(x => x.PageCategory).Include(x => x.PageComments).AsQueryable();
            var query = from page in q
                join account in _context.Accounts
                    on page.PageRegisteringEmployeeId equals account.Id
                select new PageViewModel
                {
                    PageId = page.PageId,
                    PageTittle = page.PageTittle,
                    PageCategoryId = page.PageCategoryId,
                    PageCategory = page.PageCategory.PageCategoryName,
                    PageRegisteringEmployeeId = page.PageRegisteringEmployeeId,
                    PageRegisteringEmployee = account.Username,
                    PageRegistrationDate = page.PageRegistrationDate.ToFarsi(),
                    PageIsDeleted = page.PageIsDeleted,
                    PageCommentsCount = page.PageComments.Count,
                    PagePublishDate = page.PagePublishDate.ToFarsi(),
                    PagePublishDateG = page.PagePublishDate
                };

            if (!string.IsNullOrEmpty(searchModel.PageTittle))
                query = query.Where(x => x.PageTittle.Contains(searchModel.PageTittle));
            if (searchModel.PageFromRegistrationDateG != default(DateTime))
                query = query.Where(x => x.PageRegistrationDateG >= searchModel.PageFromRegistrationDateG);
            if (searchModel.PageToRegistrationDateG != default(DateTime))
                query = query.Where(x => x.PageRegistrationDateG >= searchModel.PageToRegistrationDateG);
            if (searchModel.PageFromPublishDateG != default(DateTime))
                query = query.Where(x => x.PagePublishDateG >= searchModel.PageFromPublishDateG);
            if (searchModel.PageToPublishDateG != default(DateTime))
                query = query.Where(x => x.PagePublishDateG >= searchModel.PageToPublishDateG);
            if (searchModel.PageCategoryId != 0)
                query = query.Where(x => x.PageCategoryId == searchModel.PageCategoryId);
            if (searchModel.PageRegisteringEmployeeId != 0)
                query = query.Where(x => x.PageRegisteringEmployeeId == searchModel.PageRegisteringEmployeeId);
            query = query.Where(x => x.PageIsDeleted == searchModel.PageIsDeleted);

            recordCount = query.Count();
            query = query.OrderByDescending(x => x.PageId).Skip(searchModel.PageSize * searchModel.PageIndex)
                .Take(searchModel.PageSize);
            return query.ToList();
        }
    }
}