using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class SettingRepository: BaseRepository<int, Setting>, ISettingRepository
    {
        public SettingRepository(OkapiaContext context) : base(context)
        {
        }
    }
}
