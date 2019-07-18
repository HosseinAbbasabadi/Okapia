using Okapia.Application.Utilities;
using Okapia.Domain.ViewModels;

namespace Okapia.Application.Contracts
{
    public interface IAuthHelper
    {
        void Signin(AccountViewModel account);
        void Signout();
        AccountViewModel GetCurrnetUserInfo();
    }
}