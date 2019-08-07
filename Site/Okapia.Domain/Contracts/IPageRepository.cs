using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Page;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Page;

namespace Okapia.Domain.Contracts
{
    public interface IPageRepository : IRepository<long, Page>
    {
        EditPage GetPageDetails(long id);
        List<PageViewModel> Search(PageSearchModel searchModel, out int recordCount);
    }
}