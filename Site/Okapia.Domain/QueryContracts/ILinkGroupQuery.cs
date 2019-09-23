using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.ViewModels.LinkGroup;

namespace Okapia.Domain.QueryContracts
{
    public interface ILinkGroupQuery : IRepository<int, LinkGroup>
    {
        List<LinkGroupWithLinksViewModel> GetFooterLinkGroupsWithLinks();
    }
}
