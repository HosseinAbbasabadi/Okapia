using Framework;
using Okapia.Domain.Models;

namespace Okapia.Domain.Contracts
{
    public interface IAuthInfoRepository : IRepository<long, AuthInfo>
    {
        AuthInfo GetAuthInfoByReferenceRecord(int id, int roleId);
    }
}
