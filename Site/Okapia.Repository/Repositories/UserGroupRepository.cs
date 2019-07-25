using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class UserGroupRepository : BaseRepository<int, UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(OkapiaContext context) : base(context)
        {
        }

        public void Detach(int groupId, long userId)
        {
            //var local = _context.UserGroups.Local.Where(x => x.UserId == userId).FirstOrDefault(x => x.GroupId == groupId);
            //if (local == null) return;
            //_context.Entry(local).State = EntityState.Detached;
        }
    }
}