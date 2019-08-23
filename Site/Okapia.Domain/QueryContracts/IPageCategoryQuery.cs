using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.ViewModels.PageCategory;

namespace Okapia.Domain.QueryContracts
{
    public interface IPageCategoryQuery: IRepository<int, PageCategory>
    {
        List<PageCategoryMenuViewModel> GetPageCategoriesForMenu();
        PageCategoryBlogViewModel GetPageCategoryForBlog(string categorySlug);
    }
}
