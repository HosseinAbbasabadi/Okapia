using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Domain.QueryContracts
{
    public interface IJobQuery : IRepository<long, Job>
    {
        JobViewDetailsViewModel GetJobViewDetails(string slug);
        List<JobStaredViewModel> GetStaredJobs();
        List<JobItemViewModel> GetJobsForCategoryView(JobViewSearchModel searchModel);
        long GetActiveJobsCount();
    }
}