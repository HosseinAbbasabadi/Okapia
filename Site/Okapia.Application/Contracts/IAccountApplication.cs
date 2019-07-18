using Framework;
using Okapia.Domain.Commands;
using Okapia.Domain.Commands.User;
using Okapia.Domain.ViewModels;

namespace Okapia.Application.Contracts
{
    public interface IAccountApplication
    {
        OperationResult Login(Login login);
        OperationResult Register(CreateUser command);
        void LogoutUser();
        OperationResult Delete(long id);
        OperationResult Activate(long id);
        AccountViewModel GetAccountInfo();
        OperationResult ChangePassword(ChangePassword command);
    }
}
