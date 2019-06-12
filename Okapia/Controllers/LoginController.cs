using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okapia.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Okapia.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult SignIn([Bind("Username, Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                var cookieOptions = new CookieOptions();
                Response.Cookies.Append("Authentication", "True", cookieOptions);
                return RedirectToAction("Index", "Home");
            }
            return View("Index", login);
        }
    }
}
