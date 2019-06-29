using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Domain.Contracts
{
    public interface IJobRepository : IRepository<int, Job>
    {
        List<JobViewModel> Search(Expression<Func<JobViewModel, bool>> conditions,JobSearchModel searchModel, out int recordCount);
    }
}
