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
            var query = _context.Links.Select(x => new LinkViewModel
            {
                Id = x.LinkId,
                Label = x.LinkLabel,
                Target = x.LinkTarget,
                Category = x.LinkCategory,
                CreationDate = x.LinkCreationDate.ToFarsi(),
                IsDeleted = x.LinkIsDeleted
            });

            if (!string.IsNullOrEmpty(searchModel.Label))
                query = query.Where(x => x.Label.Contains(searchModel.Label));
            if (searchModel.Category != 0)
                query = query.Where(x => x.Category == searchModel.Category);
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
                Category = x.LinkCategory
            }).FirstOrDefault(x=>x.Id == id);
        }
    }
}