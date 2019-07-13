using Framework;
using Okapia.Domain.Commands;
using Okapia.Domain.Commands.User;
using Okapia.Domain.ViewModels.User;

namespace Okapia.Application.Contracts
{
    public interface IAccountApplication
    {
        OperationResult Login(Login login);
        OperationResult Register(CreateUser command);
        void LogoutUser();
        UserInfoViewModel GetAccountInfo();
        OperationResult ChangePassword(ChangePassword command);
    }
}
