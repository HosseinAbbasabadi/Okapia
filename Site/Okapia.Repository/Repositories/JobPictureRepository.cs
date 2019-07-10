using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class JobPictureRepository : BaseRepository<int, JobPicture>, IJobPictureRepository
    {
        private readonly OkapiaContext _context;

        public JobPictureRepository(OkapiaContext context, OkapiaContext context1) : base(context)
        {
            _context = context1;
        }

        public List<JobPicture> GetJobPicturesByJob(int id)
        {
            return _context.JobPicture.Where(x => x.JobId == id).AsNoTracking().ToList();
        }
    }
}
