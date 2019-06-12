using System;
using Microsoft.AspNetCore.Http;

namespace Okapia.Helpers
{
    public class AuthHelper
    {
        public bool IsAuthenticated { get; private set; }
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void CheckAuthentication()
        {
            IsAuthenticated = Convert.ToBoolean(_contextAccessor.HttpContext.Request.Cookies["Authentication"]);
        }
    }
}
