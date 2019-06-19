using System;

namespace Okapia_DataCollector.Model
{
    public class JobTransaction
    {
        public long Id { get; set; }
        public decimal Ammount { get; set; }
        public string PanTrunc { get; set; }
        public long Rrn { get; set; }
        public DateTime LocalDateTime { get; set; }
        public decimal TrAmmount { get; set; }
    }
}