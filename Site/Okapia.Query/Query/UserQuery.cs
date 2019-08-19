using System;
using System.Linq;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;

namespace Okapia.Query.Query
{
    public class UserQuery : BaseViewRepository<long, User>, IUserQuery
    {
        public UserQuery(OkapiaViewContext context) : base(context)
        {
        }

        public long GetActiveUsersCount()
        {
            return _context.Users.Count();
        }
    }
}
