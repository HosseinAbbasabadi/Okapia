using System.Linq;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;

namespace Okapia.Query.Query
{
    public class UserCardQuery : BaseViewRepository<long, UserCard>, IUserCardQuery
    {
        public UserCardQuery(OkapiaViewContext context) : base(context)
        {
        }

        public long GetCardCount()
        {
            return _context.UserCards.Count(x => !string.IsNullOrEmpty(x.CardNumber));
        }
    }
}
