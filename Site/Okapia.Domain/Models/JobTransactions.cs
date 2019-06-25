using System;
using System.Collections.Generic;

namespace Okapia.Domain
{
    public partial class JobTransactions
    {
        public long Id { get; set; }
        public decimal Ammount { get; set; }
        public string PanTrunc { get; set; }
        public long Rrn { get; set; }
        public DateTime LocalDateTime { get; set; }
        public decimal TrAmmount { get; set; }
    }
}