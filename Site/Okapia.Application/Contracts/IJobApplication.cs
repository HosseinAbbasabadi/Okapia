using Okapia.Application.Commands.Job;
using Okapia.Domain.Models;

namespace Okapia.Application.Contracts
{
    public interface IJobApplication
    {
        void Create(CreateJob command);
    }
}