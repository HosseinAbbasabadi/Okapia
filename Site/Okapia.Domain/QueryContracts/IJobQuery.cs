using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Domain.QueryContracts
{
    public interface IJobQuery : IRepository<long, Job>
    {
        List<JobStaredViewModel> GetStaredJobs();
    }
}