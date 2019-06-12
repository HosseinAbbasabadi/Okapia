using Okapia.Models;

namespace Okapia.Helpers
{
    public interface IAuthHelper
    {
        void Signup();
        bool Signin(Login login);
        void Signout();
        Auth GetAuthenticationInfo();
    }
}