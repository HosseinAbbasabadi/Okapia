using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.JobRequest;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.RequestJob;

namespace Okapia.Application.Contracts
{
    public interface IJobRequestApplication
    { 
        OperationResult Create(CreateJobRequest command);
        OperationResult ChangeStatus(ChangeStatus command);
        List<JobRequestViewModel> Search(JobRequestSearchModel searchModel, out int recordCount);
        JobRequest GetJobRequest(long id);
    }
}
