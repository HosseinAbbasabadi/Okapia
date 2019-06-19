using Microsoft.AspNetCore.Mvc;

namespace Okapia.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditCustomer()
        {
            var customer = new Okapia.Models.Customer
            {
                NationalCardNumber = "0020304050",
                PhoneNumber = "09102030400"
            };
            return View(customer);
        }
    }
}
