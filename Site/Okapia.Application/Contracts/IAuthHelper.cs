using Okapia.Application.Utilities;
using Okapia.Domain.ViewModels.User;

namespace Okapia.Application.Contracts
{
    public interface IAuthHelper
    {
        void Signin(string name, string userName, int role);
        void Signout();
        UserInfoViewModel GetUserInfo();
    }
}