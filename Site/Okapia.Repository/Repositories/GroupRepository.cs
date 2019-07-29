using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.Group;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Group;

namespace Okapia.Repository.Repositories
{
    public class GroupRepository : BaseRepository<int, Group>, IGroupRepository
    {
        public GroupRepository(OkapiaContext context) : base(context)
        {
            _context = context;
        }

        public List<GroupViewModel> GetGroups()
        {
            return _context.Groups.Where(x => x.IsDeleted == false).Select(group => new GroupViewModel
            {
                Id = group.GroupId,
                Name = group.GroupName
            }).ToList();
        }

        public Group GetGroup(int id)
        {
            return _context.Groups.Include(x => x.UserGroups).FirstOrDefault(x => x.GroupId == id);
        }

        public EditGroup GetGroupForDetails(int id)
        {
            return _context.Groups.Select(group => new EditGroup
            {
                Id = group.GroupId,
                Name = group.GroupName,
                Description = group.GroupDescription,
                IsDeleted = group.IsDeleted
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<GroupViewModel> Search(GroupSearchModel searchModel, out int recordCount)
        {
            var query = _context.Groups.Include(x=>x.UserGroups).Select(group => new GroupViewModel
            {
                Id = group.GroupId,
                Name = group.GroupName,
                Description = group.GroupDescription,
                IsDeleted = group.IsDeleted,
                UsersCount = group.UserGroups.Count
            });
            if (!string.IsNullOrEmpty(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            if (!string.IsNullOrEmpty(searchModel.Description))
                query = query.Where(x => x.Description.Contains(searchModel.Description));
            query = query.Where(x => x.IsDeleted == searchModel.IsDeleted);
            query = query.OrderByDescending(x => x.Id).Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);
            recordCount = query.Count();
            return query.ToList();
        }
    }
}