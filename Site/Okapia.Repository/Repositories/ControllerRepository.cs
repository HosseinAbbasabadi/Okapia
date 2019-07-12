using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class ControllerRepository : BaseRepository<int, Controller>, IControllerRepository
    {
        public ControllerRepository(OkapiaContext context) : base(context)
        {
        }
    }
}