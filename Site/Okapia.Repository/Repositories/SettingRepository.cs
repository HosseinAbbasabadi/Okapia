using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class SettingRepository: BaseRepository<int, Setting>, ISettingRepository
    {
        public SettingRepository(OkapiaContext context) : base(context)
        {
        }

        public string GetValueByKey(string key)
        {
            return _context.Settings.FirstOrDefault(x => x.SettingKey == key)?.SettingValue;
        }
    }
}
