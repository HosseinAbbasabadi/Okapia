using Framework;
using Okapia.Domain.Models;

namespace Okapia.Domain.Contracts
{
    public interface ISettingRepository : IRepository<int, Setting>
    {
        string GetValueByKey(string key);
    }
}