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
                _authHelper.SetAutheticationCookie();
                return RedirectToAction("Index", "Home");
            }
            return View("Index", login);
        }
    }
}
