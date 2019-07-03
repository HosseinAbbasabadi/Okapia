using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Job;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Domain.Contracts
{
    public interface IJobRepository : IRepository<int, Job>
    {
        Job GetJob(int id);
        EditJob GetJobDetails(int id);
        List<JobViewModel> Search(JobSearchModel searchModel, out int recordCount);
    }
}
