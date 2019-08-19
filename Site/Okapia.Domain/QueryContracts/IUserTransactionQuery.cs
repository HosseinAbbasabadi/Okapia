using Framework;
using Okapia.Domain.Models;

namespace Okapia.Domain.QueryContracts
{
    public interface IUserTransactionQuery : IRepository<long, UserTransaction>
    {
        long GetUserTransactionsCount();
    }
}