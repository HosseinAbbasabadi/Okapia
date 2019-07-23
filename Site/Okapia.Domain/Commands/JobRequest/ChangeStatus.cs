namespace Okapia.Domain.Commands.JobRequest
{
    public class ChangeStatus
    {
        public long Id { get; set; }
        public int Status { get; set; }
        public string OperatorDescription { get; set; }
    }
}
