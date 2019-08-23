using Framework;
using Okapia.Domain.Models;

namespace Okapia.Domain.QueryContracts
{
    public interface IUserCardQuery : IRepository<long, UserCard>
    {
        long GetCardCount();
    }
}
