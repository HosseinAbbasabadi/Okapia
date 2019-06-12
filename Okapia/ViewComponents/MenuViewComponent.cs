using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Okapia.Models;

namespace Okapia.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var authentication = new Auth()
            {
                IsAuthorized = false,
                Username = ""
            };

            var isAuthorized = Convert.ToBoolean(Request.Cookies["Authentication"]);
            if (isAuthorized)
            {
                authentication.IsAuthorized = true;
                authentication.Username = "Hossein";
            }
            ViewData["Auth"] = authentication;
            return View("Default", authentication);
        }
    }
}
