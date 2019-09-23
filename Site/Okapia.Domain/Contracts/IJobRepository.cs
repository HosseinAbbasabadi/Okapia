using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Job;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Domain.Contracts
{
    public interface IJobRepository : IRepository<long, Job>
    {
        Job GetJob(long id);
        Job GetJobIncludingAccount(long id);
        EditJob GetJobDetails(long id);
        List<JobViewModel> GetActiveJobs();
        List<JobViewModel> Search(JobSearchModel searchModel, out int recordCount);
    }
}