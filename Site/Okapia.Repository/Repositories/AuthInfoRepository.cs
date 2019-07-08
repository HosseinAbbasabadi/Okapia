using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class AuthInfoRepository : BaseRepository<long,AuthInfo>, IAuthInfoRepository
    {
        public AuthInfoRepository(OkapiaContext context) : base(context)
        {
        }
    }
}
