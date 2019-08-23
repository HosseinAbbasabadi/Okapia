using Okapia.Application.Contracts;
using Okapia.Domain.QueryContracts;

namespace Okapia.Application.Applications
{
    public class JobTransactionApplication : IJobTransactionApplication
    {
        private readonly IJobTransactionQuery _jobTransactionQuery;

        public JobTransactionApplication(IJobTransactionQuery jobTransactionQuery)
        {
            _jobTransactionQuery = jobTransactionQuery;
        }

        public long GetJobTransactionsCount()
        {
            return _jobTransactionQuery.GetJobTransactionsCount();
        }
    }
}
