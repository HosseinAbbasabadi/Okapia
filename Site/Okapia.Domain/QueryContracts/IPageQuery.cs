using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Page;
using Okapia.Domain.ViewModels.PageCategory;

namespace Okapia.Domain.QueryContracts
{
    public interface IPageQuery : IRepository<long, Page>
    {
        List<PageItemViewModel> GetPagesForLatestArticles();
        PageViewDetailsViewModel GetPageDetailsForView(string slug);
    }
}