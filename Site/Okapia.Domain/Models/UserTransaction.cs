using System;

namespace Okapia.Domain.Models
{
    public class UserTransaction
    {
        public long Id { get; set; }
        public decimal Ammount { get; set; }
        public string PanTrunc { get; set; }
        public long Rrn { get; set; }
        public DateTime LocalDateTime { get; set; }
        public decimal TrAmmount { get; set; }
    }
}