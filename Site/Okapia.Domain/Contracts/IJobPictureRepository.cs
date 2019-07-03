using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;

namespace Okapia.Domain.Contracts
{
    public interface IJobPictureRepository : IRepository<int, JobPicture>
    {
        List<JobPicture> GetJobPicturesByJob(int id);
    }
}
