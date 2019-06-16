using Microsoft.AspNetCore.Mvc;
using Okapia.Helpers;
using Okapia.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Okapia.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthHelper _authHelper;

        public LoginController(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

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
                if (_authHelper.Signin(login))
                {
                    return RedirectToAction("Index", "Home");
                }

                ViewData["Error"] = "نام کاربری و یا کلمه عبور اشتباه است";
                return View("Index", login);
            }
            return View("Index", login);
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            _authHelper.Signout();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AdminSignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminSignIn([Bind("Username, Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                if (_authHelper.Signin(login))
                {
                    return RedirectToAction("Index", "Home");
                }

                ViewData["Error"] = "نام کاربری و یا کلمه عبور اشتباه است";
                return View("Index", login);
            }
            return View(login);
        }
    }
}
