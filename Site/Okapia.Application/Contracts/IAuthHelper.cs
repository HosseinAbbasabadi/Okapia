using Okapia.Application.Utilities;
using Okapia.Domain.ViewModels.User;

namespace Okapia.Application.Contracts
{
    public interface IAuthHelper
    {
        void Signin(UserInfoViewModel userInfo);
        void Signout();
        UserInfoViewModel GetCurrnetUserInfo();
    }
}