using System.Collections.Generic;
using Okapia.Domain.Commands.Job;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Application.Contracts
{
    public interface IJobApplication
    {
        void Create(CreateJob command);
        void Delete(int id, string redirect301Url);
        void Activate(int id);
        void Update(int id, EditJob command);
        EditJob GetJobDetails(int id);
        List<JobViewModel> GetJobsForList(JobSearchModel searchModel, out int recordCount);
    }
}