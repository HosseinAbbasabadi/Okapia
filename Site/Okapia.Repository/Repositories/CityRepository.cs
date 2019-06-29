using Okapia.Domain;
using Okapia.Domain.Contracts;

namespace Okapia.Repository.Repositories
{
    public class CityRepository : BaseRepository<int, City>, ICityRepository
    {
        public CityRepository(OkapiaContext context) : base(context)
        {
        }
    }
}