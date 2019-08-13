using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Query.Query
{
    public class JobQuery : BaseViewRepository<long, Job>, IJobQuery
    {
        public JobQuery(OkapiaViewContext context) : base(context)
        {
        }

        public List<JobStaredViewModel> GetStaredJobs()
        {
            return _context.Jobs.OrderByDescending(x => x.JobId).Include(x => x.JobPictures).Include(x => x.Account)
                .Where(x => x.IsStared && !x.Account.IsDeleted)
                .Select(job =>
                    new JobStaredViewModel
                    {
                        JobId = job.JobId,
                        JobName = job.JobName,
                        JobSmallDescription = job.JobSmallDescription,
                        JobPictureName = job.JobPictures.First(x => x.IsDefault).JobPictureName,
                        JobPictureAlt = job.JobPictures.First(x => x.IsDefault).JobPictureAlt,
                    }).ToList();
        }
    }
}