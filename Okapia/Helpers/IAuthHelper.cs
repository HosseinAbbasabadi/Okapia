using Okapia.Models;

namespace Okapia.Helpers
{
    public interface IAuthHelper
    {
        void SetAutheticationCookie();
        Auth GetAuthenticationInfo();
    }
}