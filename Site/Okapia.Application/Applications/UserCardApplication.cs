using Okapia.Application.Contracts;
using Okapia.Domain.QueryContracts;

namespace Okapia.Application.Applications
{
    public class UserCardApplication: IUserCardApplication
    {
        private readonly IUserCardQuery _userCardQuery;

        public UserCardApplication(IUserCardQuery userCardQuery)
        {
            _userCardQuery = userCardQuery;
        }

        public long GetCardCount()
        {
            return _userCardQuery.GetCardCount();
        }
    }
}
