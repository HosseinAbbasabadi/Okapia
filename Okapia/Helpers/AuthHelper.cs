using System;
using Microsoft.AspNetCore.Http;
using Okapia.Models;

namespace Okapia.Helpers
{
    public class AuthHelper : IAuthHelper
    {
        private const string AuthecticationCookieName = "Authentication";
        public bool IsAuthenticated { get; private set; }
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void Signout()
        {
            _contextAccessor.HttpContext.Response.Cookies.Delete(AuthecticationCookieName);
        }

        public Auth GetAuthenticationInfo()
        {
            var authentication = new Auth();

            var isAuthorized = Convert.ToBoolean(_contextAccessor.HttpContext.Request.Cookies[AuthecticationCookieName]);
            if (!isAuthorized) return authentication;
            IsAuthenticated = true;
            authentication.IsAuthorized = true;
            authentication.Username = "حسین";

            return authentication;
        }

        public void Signup()
        {
            SetAuthenticationCookie();
        }

        public bool Signin(Login login)
        {
            if (login.Username == "Hossein" && login.Password == "123456")
            {
                SetAuthenticationCookie();
                return true;
            }
            return false;

        }

        private void SetAuthenticationCookie()
        {
            var cookieOptions = new CookieOptions {Expires = DateTime.Now.AddDays(1), IsEssential = true};
            _contextAccessor.HttpContext.Response.Cookies.Append(AuthecticationCookieName, "True", cookieOptions);
        }
    }
}
