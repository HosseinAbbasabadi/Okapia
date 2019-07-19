using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class HomeController : Controller
    {
        private readonly IAccountApplication _accountApplication;

        public HomeController(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}