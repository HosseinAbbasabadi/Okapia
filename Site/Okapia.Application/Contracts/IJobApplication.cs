using System.Collections.Generic;
using Okapia.Application.Commands.Job;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Application.Contracts
{
    public interface IJobApplication
    {
        void Create(CreateJob command);
        List<JobViewModel> GetJobsForList(JobSearchModel searchModel);
    }
}