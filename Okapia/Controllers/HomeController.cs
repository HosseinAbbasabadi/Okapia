using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Okapia.Models;

namespace Okapia.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var authentication = new Auth();
            var isAuthorized = Convert.ToBoolean(Request.Cookies["Authentication"]);
            if (isAuthorized)
            {
                authentication.IsAuthorized = true;
                authentication.Username = "Hossein";
            }
            ViewData["Auth"] = authentication;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
