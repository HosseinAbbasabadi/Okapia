using Framework;
using Okapia.Domain.Models;

namespace Okapia.Domain.Contracts
{
    public interface IAuthInfoRepository : IRepository<long, AuthInfo>
    {
        AuthInfo GetAuthInfoByReferenceRecord(long id, int roleId);
        AuthInfo GetChnagePasswordInfo(long id);
    }
}
