using Framework;
using Okapia.Domain.Models;

namespace Okapia.Domain.Contracts
{
    public interface IAccountRepository : IRepository<long, Account>
    {
        Account GetAccountByReferenceRecord(long id, int roleId);
        Account GetChnagePasswordInfo(long id);
    }
}
