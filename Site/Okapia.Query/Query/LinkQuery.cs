using System.Collections.Generic;
using System.Linq;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.ViewModels.Link;

namespace Okapia.Query.Query
{
    public class LinkQuery : BaseViewRepository<int, Link>, ILinkQuery
    {
        public LinkQuery(OkapiaViewContext context) : base(context)
        {
        }

        public List<LinkSiteViewModel> GetLinks()
        {
            return _context.Links.Where(x => x.LinkIsDeleted == false).Select(link => new LinkSiteViewModel
            {
                Label = link.LinkLabel,
                Target = link.LinkTarget,
                Category = link.LinkGroupId
            }).ToList();
        }
    }
}