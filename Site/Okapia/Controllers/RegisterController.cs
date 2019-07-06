using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Domain.Commands.User;
using Okapia.Helpers;
using Okapia.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Okapia.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAuthHelper _authHelper;
        private readonly IUserApplication _userApplication;

        public RegisterController(IAuthHelper authHelper, IUserApplication userApplication)
        {
            _authHelper = authHelper;
            _userApplication = userApplication;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Register([Bind("Name, Family, NationalCardNumber, PhoneNumber, Address, Card1, Card2, Card3")]CreateUser createUser)
        {
            _userApplication.RegisterUser(createUser);
            if (ModelState.IsValid)
            {
                _authHelper.Signup();
                return RedirectToAction("Index", "Home");
            }
            return View("Index", createUser);
        }

    }
}
