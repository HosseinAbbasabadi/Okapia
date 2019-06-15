using System;
using Microsoft.AspNetCore.Http;
using Okapia.Models;

namespace Okapia.Helpers
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void Signout()
        {
            _contextAccessor.HttpContext.Response.Cookies.Delete(Constants.Cookies.AuthecticationCookieName);
            _contextAccessor.HttpContext.Response.Cookies.Delete(Constants.Cookies.RoleCookieName);
            _contextAccessor.HttpContext.Response.Cookies.Delete(Constants.Cookies.UsernameCookieName);
        }

        public Auth GetAuthenticationInfo()
        {
            var authentication = new Auth();
            var isAuthorized = Convert.ToBoolean(_contextAccessor.HttpContext.Request.Cookies[Constants.Cookies.AuthecticationCookieName]);
            if (!isAuthorized) return authentication;
            var username = _contextAccessor.HttpContext.Request.Cookies[Constants.Cookies.UsernameCookieName];
            var role = _contextAccessor.HttpContext.Request.Cookies[Constants.Cookies.RoleCookieName];
            authentication = new Auth(true, username, role);
            return authentication;
        }

        public void Signup()
        {
            SetAuthenticationCookie(Constants.Roles.Customer, "");
        }

        public bool Signin(Login login)
        {
            //TODO: OCP!!! :|
            if (login.Username == Constants.Names.Hossein && login.Password == "123456")
            {
                SetAuthenticationCookie(Constants.Roles.Administrator, Constants.Names.Hossein);
                return true;
            }

            if (login.Username == Constants.Names.Ali && login.Password == "123456")
            {
                SetAuthenticationCookie(Constants.Roles.Customer, Constants.Names.Ali);
                return true;
            }

            if (login.Username == Constants.Names.Hasan && login.Password == "123456")
            {
                SetAuthenticationCookie(Constants.Roles.ShopKeeper, Constants.Names.Hasan);
                return true;
            }

            return false;

        }

        private void SetAuthenticationCookie(string role, string username)
        {
            var cookieOptions = new CookieOptions {Expires = DateTime.Now.AddDays(1), IsEssential = true};
            _contextAccessor.HttpContext.Response.Cookies.Append(Constants.Cookies.AuthecticationCookieName, "True", cookieOptions);
            _contextAccessor.HttpContext.Response.Cookies.Append(Constants.Cookies.RoleCookieName, role, cookieOptions);
            _contextAccessor.HttpContext.Response.Cookies.Append(Constants.Cookies.UsernameCookieName, username, cookieOptions);
        }
    }
}
