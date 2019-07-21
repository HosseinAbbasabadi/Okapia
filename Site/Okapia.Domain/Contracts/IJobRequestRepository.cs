using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.RequestJob;

namespace Okapia.Domain.Contracts
{
    public interface IJobRequestRepository : IRepository<long, JobRequest>
    {
        List<JobRequestViewModel> Search(JobRequestSearchModel searchModel, out int recordCount);
    }
}