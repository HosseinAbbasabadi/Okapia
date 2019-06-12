using System;
using Microsoft.AspNetCore.Http;
using Okapia.Models;

namespace Okapia.Helpers
{
    public class AuthHelper : IAuthHelper
    {
        public bool IsAuthenticated { get; private set; }
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Auth GetAuthenticationInfo()
        {
            var authentication = new Auth();

            var isAuthorized = Convert.ToBoolean(_contextAccessor.HttpContext.Request.Cookies["Authentication"]);
            if (!isAuthorized) return authentication;
            authentication.IsAuthorized = true;
            authentication.Username = "Hossein";

            return authentication;
        }

        public void SetAutheticationCookie()
        {
            var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(1), IsEssential = true};
            _contextAccessor.HttpContext.Response.Cookies.Append("Authentication", "True", cookieOptions);
        }
    }
}
