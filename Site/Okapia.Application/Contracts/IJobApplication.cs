using Okapia.Application.Commands.Job;

namespace Okapia.Application.Contracts
{
    public interface IJobApplication
    {
        void Create(CreateJob command);
    }
}