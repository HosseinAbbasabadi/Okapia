using Microsoft.AspNetCore.Mvc;
using Okapia.Domain.Commands;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ChnagePassword(long id)
        {
            var model = new ChangePassword();
            ViewData["employeeId"] = id;
            return PartialView("_ChangePassword", model);
        }
    }
}