using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Link;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Link;

namespace Okapia.Domain.Contracts
{
    public interface ILinkRepository : IRepository<int, Link>
    {
        List<LinkViewModel> Search(LinkSearchModel searchModel, out int recordCount);
        EditLink GetDetails(int id);
    }
}