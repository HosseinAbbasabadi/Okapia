using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.JobRequest
{
    public class EditJobRequest : CreateJobRequest
    {
        public long Id { get; set; }
        public int Condition { get; set; }
        public string OperatorDescription { get; set; }
        public SelectList Cities { get; set; }
    }
}