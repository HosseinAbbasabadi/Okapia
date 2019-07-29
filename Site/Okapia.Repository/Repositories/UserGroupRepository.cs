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
    }
}