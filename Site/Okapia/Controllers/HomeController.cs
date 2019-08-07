using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Areas.Administrator.Controllers;
using Okapia.Domain.Commands.JobRequest;
using Okapia.Models;

namespace Okapia.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobRequestApplication _jobRequestApplication;
        private readonly ICityApplication _cityApplication;
        private readonly IDistrictApplication _districtApplication;
        private readonly INeighborhoodApplication _neighborhoodApplication;

        public HomeController(IJobRequestApplication jobRequestApplication, ICityApplication cityApplication,
            IDistrictApplication districtApplication, INeighborhoodApplication neighborhoodApplication)
        {
            _jobRequestApplication = jobRequestApplication;
            _cityApplication = cityApplication;
            _districtApplication = districtApplication;
            _neighborhoodApplication = neighborhoodApplication;
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
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
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