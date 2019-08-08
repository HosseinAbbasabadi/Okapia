using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class UserCardRepository : BaseRepository<long, UserCard>, IUserCardRepository
    {
        public UserCardRepository(OkapiaContext context) : base(context)
        {
        }
    }
}