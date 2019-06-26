using Framework;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class JobRepository : BaseRepository<int, Job>, IJobRepository
    {
        public JobRepository(OkapiaContext context) : base(context)
        {
        }
    }

}
