using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.ViewModels.Link;

namespace Okapia.Domain.QueryContracts
{
    public interface ILinkQuery : IRepository<int, Link>
    {
        List<LinkSiteViewModel> GetLinks();
    }
}