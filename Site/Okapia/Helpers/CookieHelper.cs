using System;
using Microsoft.AspNetCore.Http;

namespace Okapia.Helpers
{
    public class CookieHelper : ICookieHelper
    {
        private readonly IHttpContextAccessor _httpContext;

        public CookieHelper(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public string Get(string key)
        {
            var province = _httpContext.HttpContext.Request.Cookies["province"];
            if (string.IsNullOrEmpty(province))
                province = "البرز";
            return province;
        }

        public void Set(string key, string value)
        {
            CookieOptions option = new CookieOptions {Expires = DateTime.Now.AddDays(2), IsEssential = true};

            _httpContext.HttpContext.Response.Cookies.Append(key, value, option);
        }
    }
}