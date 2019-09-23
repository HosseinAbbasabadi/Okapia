using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.LinkGroup;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.LinkGroup;

namespace Okapia.Domain.Contracts
{
    public interface ILinkGroupRepository : IRepository<int, LinkGroup>
    {
        EditLinkGroup GetLinkGroupDetails(int id);
        List<LinkGroupViewModel> Search(LinkGroupSearchModel searchModel, out int recordCount);
    }
}
