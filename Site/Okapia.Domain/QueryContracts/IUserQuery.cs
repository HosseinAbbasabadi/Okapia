using Framework;
using Okapia.Domain.Models;

namespace Okapia.Domain.QueryContracts
{
    public interface IUserQuery : IRepository<long, User>
    {
        long GetActiveUsersCount();
    }
}
