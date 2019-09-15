using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;

namespace Okapia.Query.Query
{
    public class BoxQuery : BaseViewRepository<int, Box>, IBoxQuery
    {
        public BoxQuery(OkapiaViewContext context) : base(context)
        {
        }
    }
}