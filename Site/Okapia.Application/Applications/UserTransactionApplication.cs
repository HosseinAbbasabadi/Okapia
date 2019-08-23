using Okapia.Application.Contracts;
using Okapia.Domain.QueryContracts;

namespace Okapia.Application.Applications
{
    public class UserTransactionApplication : IUserTransactionApplication
    {
        private readonly IUserTransactionQuery _userTransactionQuery;

        public UserTransactionApplication(IUserTransactionQuery userTransactionQuery)
        {
            _userTransactionQuery = userTransactionQuery;
        }

        public long GetUserTransactionsCount()
        {
            return _userTransactionQuery.GetUserTransactionsCount();
        }
    }
}