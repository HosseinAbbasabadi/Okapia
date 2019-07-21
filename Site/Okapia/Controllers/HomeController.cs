using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Areas.Administrator.Controllers;
using Okapia.Domain.Commands.RequestJob;
using Okapia.Models;

namespace Okapia.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobRequestApplication _jobRequestApplication;

        public HomeController(IJobRequestApplication jobRequestApplication)
        {
            _jobRequestApplication = jobRequestApplication;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Agency()
        {
            var createJobRequest = new CreateJobRequest()
            {
                Provinces = new SelectList(Provinces.ToList(), "Id", "Name")
            };
            return View(createJobRequest);
        }

        [HttpPost]
        public JsonResult Agency(CreateJobRequest command)
        {
            var result = _jobRequestApplication.Create(command);
            return Json(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
