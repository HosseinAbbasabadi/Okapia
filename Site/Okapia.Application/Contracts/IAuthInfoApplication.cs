using Framework;
using Okapia.Domain.Commands;

namespace Okapia.Application.Contracts
{
    public interface IAuthInfoApplication
    {
        void Register();
        OperationResult ChangePassword(ChangePassword command);
    }
}
