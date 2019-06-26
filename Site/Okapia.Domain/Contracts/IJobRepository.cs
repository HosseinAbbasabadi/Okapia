using Framework;
using Okapia.Domain.Models;

namespace Okapia.Domain.Contracts
{
    public interface IJobRepository : IRepository<int, Job>
    {
    }
}
