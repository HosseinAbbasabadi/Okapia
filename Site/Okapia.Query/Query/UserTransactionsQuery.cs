using System.Linq;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;

namespace Okapia.Query.Query
{
    public class UserTransactionsQuery : BaseViewRepository<long, UserTransaction>, IUserTransactionQuery
    {
        public UserTransactionsQuery(OkapiaViewContext context) : base(context)
        {
        }

        public long GetUserTransactionsCount()
        {
            return _context.UserTransactions.Count();
        }
    }
}
