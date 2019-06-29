using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class CategoryRepository : BaseRepository<int,Category>, ICategoryRepository
    {
        public CategoryRepository(OkapiaContext context) : base(context)
        {
        }
    }
}
