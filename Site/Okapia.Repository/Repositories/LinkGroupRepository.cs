using System.Collections.Generic;
using System.Linq;
using Framework;
using Okapia.Domain.Commands.LinkGroup;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.LinkGroup;

namespace Okapia.Repository.Repositories
{
    public class LinkGroupRepository : BaseRepository<int, LinkGroup>, ILinkGroupRepository
    {
        public LinkGroupRepository(OkapiaContext context) : base(context)
        {
        }

        public EditLinkGroup GetLinkGroupDetails(int id)
        {
            return _context.LinkGroups.Select(x => new EditLinkGroup
            {
                Id = x.Id,
                Name = x.Name,
                IsDeleted = x.IsDeleted
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<LinkGroupViewModel> Search(LinkGroupSearchModel searchModel, out int recordCount)
        {
            var query = _context.LinkGroups.Join(_context.Accounts, group => group.CreatorAccountId,
                account => account.Id, (group, account) => new LinkGroupViewModel
                {
                    Id = group.Id,
                    Name = group.Name,
                    CreationDate = group.CreationDate.ToFarsi(),
                    IsDeleted = group.IsDeleted,
                    CreatorUsername = account.Username
                });

            if (!string.IsNullOrEmpty(searchModel.Name))
                query = query.Where(x => x.Name == searchModel.Name);
            query = query.Where(x => x.IsDeleted == searchModel.IsDeleted);

            recordCount = query.Count();
            query = query.OrderByDescending(x => x.Id).Skip(searchModel.PageSize * searchModel.PageIndex)
                .Take(searchModel.PageSize);
            return query.ToList();
        }
    }
}