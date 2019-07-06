using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class AuthInfoRepository : BaseRepository<long,AuthInfo>, IAuthInfoRepository
    {
        private readonly OkapiaContext _context;
        public AuthInfoRepository(OkapiaContext context, OkapiaContext context1) : base(context)
        {
            _context = context1;
        }
    }
}
