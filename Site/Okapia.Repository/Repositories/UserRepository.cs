using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class UserRepository : BaseRepository<long, User>, IUserRepository
    {
        private readonly OkapiaContext _context;
        public UserRepository(OkapiaContext context, OkapiaContext context1) : base(context)
        {
            _context = context1;
        }
    }
}
