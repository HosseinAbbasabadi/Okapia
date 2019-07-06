using System;

namespace Framework
{
    public class OperationResult
    {
        public long RecordId { get; set; }
        public string TableName { get; set; }
        public DateTime OperationDate { get; set; }
        public string Operation { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
