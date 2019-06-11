using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okapia.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Okapia.Mvc.Controllers
{
    public class RegisterController : Controller
    {

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
                var cookieOptions = new CookieOptions();
                Response.Cookies.Append("Authentication", "True",cookieOptions);
                return RedirectToAction("Index", "Home");
            }
            return View("Index", customer);
        }

    }
}
