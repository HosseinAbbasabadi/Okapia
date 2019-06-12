using Microsoft.AspNetCore.Mvc;
using Okapia.Helpers;
using Okapia.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Okapia.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAuthHelper _authHelper;

        public RegisterController(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult SignUp([Bind("Name, Family, NationalCardNumber, PhoneNumber, Address, Card1, Card2, Card3")]Customer customer)
        {
            if (ModelState.IsValid)
            {
                _authHelper.Signup();
                return RedirectToAction("Index", "Home");
            }
            return View("Index", customer);
        }

    }
}
