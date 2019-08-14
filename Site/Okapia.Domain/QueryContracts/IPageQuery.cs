using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.ViewModels.Page;

namespace Okapia.Domain.QueryContracts
{
    public interface IPageQuery : IRepository<long, Page>
    {
        List<PageItemViewModel> GetPagesForLatestArticles();
        List<PageItemViewModel> GetPagesForBlogBy(int categoryId);
    }
}