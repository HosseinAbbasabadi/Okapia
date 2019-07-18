using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Okapia.Application.Contracts;
using Okapia.Domain.ViewModels;

namespace Okapia.Application.Applications
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
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public AccountViewModel GetCurrnetUserInfo()
        {
            if (_contextAccessor.HttpContext.User.Claims.FirstOrDefault() == null) return new AccountViewModel();
            var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            var userId = long.Parse(claims.First(x => x.Type == "UserId").Value);
            var referenceRecordId = long.Parse(claims.First(x => x.Type == "ReferenceRecordId").Value);
            var name = claims.First(x => x.Type == ClaimTypes.Name).Value;
            var username = claims.First(x => x.Type == "Username").Value;
            var role = int.Parse(claims.First(x => x.Type == ClaimTypes.Role).Value);
            return new AccountViewModel(userId, referenceRecordId, name, username, role);
        }

        public void Signin(AccountViewModel account)
        {
            var claims = new List<Claim>
            {
                new Claim("UserId", account.AuthUserId.ToString()),
                new Claim("ReferenceRecordId", account.ReferenceRecordId.ToString()),
                new Claim("Username", account.Username),
                new Claim(ClaimTypes.Name, account.Name),
                new Claim(ClaimTypes.Role, account.Role.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(3),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            _contextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}