using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.PageCategory;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.PageCategory;

namespace Okapia.Domain.Contracts
{
    public interface IPageCategoryRepository : IRepository<int, PageCategory>
    {
        EditPageCategory GetPageCategoryDetails(int id);
        List<PageCategoryViewModel> GetPageCategories();
        List<PageCategoryViewModel> Search(PageCategorySearchModel searchModel, out int recordCount);
    }
}