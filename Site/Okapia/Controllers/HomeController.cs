using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Areas.Administrator.Controllers;
using Okapia.Domain.Commands.JobRequest;
using Okapia.Domain.SeachModels;
using Okapia.Models;
using reCAPTCHA.AspNetCore;

namespace Okapia.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobRequestApplication _jobRequestApplication;
        private readonly ICityApplication _cityApplication;
        private readonly IDistrictApplication _districtApplication;
        private readonly INeighborhoodApplication _neighborhoodApplication;
        private readonly IRecaptchaService _recaptchaService;

        public HomeController(IJobRequestApplication jobRequestApplication, ICityApplication cityApplication,
            IDistrictApplication districtApplication, INeighborhoodApplication neighborhoodApplication,
            IJobApplication jobApplication, IRecaptchaService recaptchaService)
        {
            _jobRequestApplication = jobRequestApplication;
            _cityApplication = cityApplication;
            _districtApplication = districtApplication;
            _neighborhoodApplication = neighborhoodApplication;
            _recaptchaService = recaptchaService;
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
        [ValidateAntiForgeryToken]
        public ActionResult Agency(CreateJobRequest command)
        {
            var recaptcha = _recaptchaService.Validate(Request);
            if (!recaptcha.IsCompletedSuccessfully)
            {
                ViewData["errorMessage"] = "خطای اعتبارسنجی. لطفا دوباره تلاش کنید";
                return View();
            }

            var result = _jobRequestApplication.Create(command);
            if (result.Success)
            {
                ViewData["name"] = command.ContactTitle;
                return View("AgencySuccess", result.RecordId.ToString());
            }

            ViewData["errorMessage"] = result.Message;
            return View();
        }

        public ActionResult AgencySuccess()
        {
            return View();
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
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public ActionResult Search([FromForm] string q)
        {
            var search = new JobViewSearchModel
            {
                Text = q
            };
            return RedirectToAction("Index", "JobView", search);
        }

        [HttpGet]
        public JsonResult GetCitiesByProvince(int id)
        {
            var cities = _cityApplication.GetCitiesBy(id);
            return new JsonResult(cities);
        }

        [HttpGet]
        public JsonResult GetDistrictsByCity(int id)
        {
            var cities = _districtApplication.GetDistrictsBy(id);
            return new JsonResult(cities);
        }

        [HttpGet]
        public JsonResult GetNeighborhoodsByDistrict(int id)
        {
            var cities = _neighborhoodApplication.GetNeighborhoodsBy(id);
            return new JsonResult(cities);
        }
    }
}