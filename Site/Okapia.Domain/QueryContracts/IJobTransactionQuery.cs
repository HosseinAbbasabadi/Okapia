using Framework;
using Okapia.Domain.Models;

namespace Okapia.Domain.QueryContracts
{
    public interface IJobTransactionQuery : IRepository<long, JobTransaction>
    {
        long GetJobTransactionsCount();
    }
}