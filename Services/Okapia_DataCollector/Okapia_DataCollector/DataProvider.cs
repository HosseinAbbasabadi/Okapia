using System;
using System.Collections.Generic;
using Okapia_DataCollector.Model;

namespace Okapia_DataCollector
{
    public static class DataProvider
    {
        public static List<JobTransaction> ProvideSomeJobTransactions(int count)
        {
            var transactions = new List<JobTransaction>();
            for (var i = 0; i <= count; i++)
            {
                var transaction = new JobTransaction()
                {
                    Id = i,
                    Ammount = 45000,
                    LocalDateTime = DateTime.Now,
                    PanTrunc = "6104337794652121",
                    Rrn = 45964,
                    TrAmmount = 40000
                };
                transactions.Add(transaction);
            }

            return transactions;
        }
    }
}