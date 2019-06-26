using Okapia.Domain.Models;

namespace Okapia.Application.Contracts
{
    public interface IJobApplication
    {
        void Create(Job job);
    }
}