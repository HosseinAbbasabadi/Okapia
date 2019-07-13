using Microsoft.AspNetCore.Mvc;
using Okapia.Domain.Commands;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [ServiceFilter(typeof(AuthorizeFilter))]
    [Area("Administrator")]
    //[CustomAuthorization(ControllerId = 11)]
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