using System.Collections.Generic;
using System.Linq;
using Framework;
using Okapia.Domain.Commands.Link;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Link;

namespace Okapia.Repository.Repositories
{
    public class LinkRepository : BaseRepository<int, Link>, ILinkRepository
    {
        public LinkRepository(OkapiaContext context) : base(context)
        {
        }

        public List<LinkViewModel> Search(LinkSearchModel searchModel, out int recordCount)
        {
            var query = _context.Links.Join(_context.LinkGroups, link => link.LinkGroupId, group => group.Id, (link, group) => new LinkViewModel
            {
                Id = link.LinkId,
                Label = link.LinkLabel,
                Target = link.LinkTarget,
                GroupId = link.LinkGroupId,
                Group = group.Name,
                CreationDate = link.LinkCreationDate.ToFarsi(),
                IsDeleted = link.LinkIsDeleted
            });

            if (!string.IsNullOrEmpty(searchModel.Label))
                query = query.Where(x => x.Label.Contains(searchModel.Label));
            if (searchModel.Group != 0)
                query = query.Where(x => x.GroupId == searchModel.Group);
            query = query.Where(x => x.IsDeleted == searchModel.IsDeleted);
            recordCount = query.Count();
            query = query.OrderByDescending(x => x.Id).Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);
            return query.ToList();
        }

        public EditLink GetDetails(int id)
        {
            return _context.Links.Select(x => new EditLink
            {
                Id = x.LinkId,
                Label = x.LinkLabel,
                Target = x.LinkTarget,
                IsDeleted = x.LinkIsDeleted,
                Group = x.LinkGroupId
            }).FirstOrDefault(x=>x.Id == id);
        }
    }
}