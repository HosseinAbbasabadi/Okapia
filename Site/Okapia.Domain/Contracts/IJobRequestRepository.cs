using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.JobRequest;

namespace Okapia.Domain.Contracts
{
    public interface IJobRequestRepository : IRepository<long, JobRequest>
    {
        JobRequest GetJobRequest(long id);
        JobRequestViewModel GetJobRequestDetails(long id);
        List<JobRequestViewModel> Search(JobRequestSearchModel searchModel, out int recordCount);
    }
}