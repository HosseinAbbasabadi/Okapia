using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.RequestJob;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.RequestJob;

namespace Okapia.Application.Contracts
{
    public interface IJobRequestApplication
    {
        OperationResult Create(CreateJobRequest command);
        List<JobRequestViewModel> Search(JobRequestSearchModel searchModel, out int recordCount);
    }
}
