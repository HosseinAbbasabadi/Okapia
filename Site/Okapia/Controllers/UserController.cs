using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Domain.Commands.User;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Okapia.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public ActionResult Register()
        {
            var createUser = new CreateUser();
            return View("Register", createUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CreateUser createUser)
        {
            if (!ModelState.IsValid) return View("Register", createUser);
            var result = _userApplication.RegisterUser(createUser);
            if (result.Success)
                return RedirectToAction("Index", "Home");
            ViewData["errorMessage"] = result.Message;
            return View("Register", createUser);
        }

        public ActionResult Login()
        {
            var login = new Login();
            return View("Login", login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (!ModelState.IsValid) return View("Login", login);
            var result = _userApplication.LoginUser(login);
            if(result.Success)
                return RedirectToAction("Index", "Home");
            else
            {
                ViewData["errorMessage"] = result.Message;
                return View("Login", login);
            }
        }

        public ActionResult Logout()
        {
            _userApplication.LogoutUser();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AccessDenied()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}