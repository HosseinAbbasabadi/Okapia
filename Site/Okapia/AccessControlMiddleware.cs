using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Okapia
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AccessControlMiddleware
    {
        private readonly RequestDelegate _next;

        public AccessControlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AuthenticationException exception)
            {
                Console.WriteLine(exception);
                httpContext.Response.Redirect("/Account/AccessDenied");
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AccessControlMiddlewareExtensions
    {
        public static IApplicationBuilder UseAccessControlMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AccessControlMiddleware>();
        }
    }
}
