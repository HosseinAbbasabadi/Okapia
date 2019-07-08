using Framework;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.User;
using Okapia.Domain.ViewModels.User;

namespace Okapia.Application.Contracts
{
    public interface IUserApplication
    {
        OperationResult LoginUser(Login login);
        OperationResult RegisterUser(CreateUser command);
        void LogoutUser();
        UserInfoViewModel GetUserInfo();
    }
}
