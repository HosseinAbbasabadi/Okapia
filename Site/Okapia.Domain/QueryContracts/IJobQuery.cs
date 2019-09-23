using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Domain.QueryContracts
{
    public interface IJobQuery : IRepository<long, Job>
    {
        List<JobSearchResultViewModel> Search(string phrase, string province);
        List<JobItemViewModel> SearchResult(string phrase, string province);
        JobViewDetailsViewModel GetJobViewDetails(string slug);
        List<JobItemViewModel> GetJobsForCategoryView(JobViewSearchModel searchModel);
        List<JobItemViewModel> GetJobsByCatgoryId(int categoryId);
        long GetActiveJobsCount();
    }
}