using Framework;
using Okapia.Domain.Models;

namespace Okapia.Domain.Contracts
{
    public interface IUserRepository : IRepository<long, User>
    {
    }
}
