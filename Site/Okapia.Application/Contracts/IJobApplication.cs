using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Job;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Application.Contracts
{
    public interface IJobApplication
    {
        OperationResult Create(CreateJob command);
        OperationResult Delete(int id, string redirect301Url);
        void Activate(int id);
        OperationResult Update(int id, EditJob command);
        EditJob GetJobDetails(int id);
        List<JobViewModel> GetJobsForList(JobSearchModel searchModel, out int recordCount);
        OperationResult CheckJobSlugDuplication(string slug);
    }
}