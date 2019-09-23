using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.ViewModels.Link;
using Okapia.Domain.ViewModels.LinkGroup;

namespace Okapia.Query.Query
{
    public class LinkGroupQuery : BaseViewRepository<int, LinkGroup>, ILinkGroupQuery
    {
        public LinkGroupQuery(OkapiaViewContext context) : base(context)
        {
        }

        public List<LinkGroupWithLinksViewModel> GetFooterLinkGroupsWithLinks()
        {
            return _context.LinkGroups.Include(x => x.Links).Where(x => !x.IsDeleted)
                .Select(x => new LinkGroupWithLinksViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Links = MapLinks(x.Links)
                }).ToList();
        }

        private static List<LinkViewModel> MapLinks(IEnumerable<Link> links)
        {
            return links.Select(MapLink).ToList();
        }

        private static LinkViewModel MapLink(Link link)
        {
            return new LinkViewModel
            {
                Id = link.LinkGroupId,
                Label = link.LinkLabel,
                Target = link.LinkTarget
            };
        }
    }
}