using Framework;
using Okapia.Domain.Commands;

namespace Okapia.Application.Contracts
{
    public interface IAuthInfoApplication
    {
        OperationResult ChangePassword(ChangePassword command);
    }
}
