using System;
using System.Linq;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;

namespace Okapia.Query.Query
{
    public class JobTransactionQuery : BaseViewRepository<long, JobTransaction>, IJobTransactionQuery
    {
        public JobTransactionQuery(OkapiaViewContext context) : base(context)
        {
        }

        public long GetJobTransactionsCount()
        {
            return _context.JobTransactions.Count();
        }
    }
}
