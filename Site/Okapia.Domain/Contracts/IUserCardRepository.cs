using Framework;
using Okapia.Domain.Models;

namespace Okapia.Domain.Contracts
{
    public interface IUserCardRepository : IRepository<long, UserCard>
    {
    }
}
