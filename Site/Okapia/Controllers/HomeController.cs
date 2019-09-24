﻿using System.Diagnostics;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Areas.Administrator.Controllers;
using Okapia.Domain.Commands.Contactus;
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
        private readonly IModalApplication _modalApplication;
        private readonly IAuthHelper _authHelper;
        private readonly ISettingApplication _settingApplication;
        private readonly IContactApplication _contactApplication;
        private readonly ICookieHelper _cookieHelper;

        public HomeController(IJobRequestApplication jobRequestApplication, ICityApplication cityApplication,
            IDistrictApplication districtApplication, INeighborhoodApplication neighborhoodApplication,
            IJobApplication jobApplication, IRecaptchaService recaptchaService, IModalApplication modalApplication,
            IAuthHelper authHelper, ISettingApplication settingApplication, IContactApplication contactApplication,
            ICookieHelper cookieHelper)
        {
            _jobRequestApplication = jobRequestApplication;
            _cityApplication = cityApplication;
            _districtApplication = districtApplication;
            _neighborhoodApplication = neighborhoodApplication;
            _recaptchaService = recaptchaService;
            _modalApplication = modalApplication;
            _authHelper = authHelper;
            _settingApplication = settingApplication;
            _contactApplication = contactApplication;
            _cookieHelper = cookieHelper;
        }

        public IActionResult Index([FromQuery(Name = "pn")] string pn)
        {
            var province = _cookieHelper.Get("province");
            if (!string.IsNullOrEmpty(pn))
                province = pn;
            if (string.IsNullOrEmpty(province))
                province = "البرز";
            _cookieHelper.Set("province", province);
            ViewData["province"] = province;
            return View();
        }

        [ActionName("درخواست-ثبت-نمایندگی-اُکاپیا")]
        public IActionResult Agency()
        {
            var createJobRequest = new CreateJobRequest
            {
                Provinces = new SelectList(Provinces.ToList(), "Id", "Name")
            };
            return View("Agency", createJobRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agency(CreateJobRequest command)
        {
            var result = _jobRequestApplication.Create(command);
            if (result.Success)
            {
                ViewData["name"] = command.ContactTitle;
            ViewData["province"] = _cookieHelper.Get("province");
                return View("AgencySuccess", result.RecordId.ToString());
            }

            ViewData["errorMessage"] = result.Message;
            ViewData["province"] = _cookieHelper.Get("province");
            return View();
        }

        [ActionName("ثبت-موفق-نمایندگی-در-اُکاپیا")]
        public ActionResult AgencySuccess()
        {
            ViewData["province"] = _cookieHelper.Get("province");
            return View("AgencySuccess");
        }

        [ActionName("قوانین-و-مقررات")]
        public IActionResult Privacy()
        {
            var privacy = _settingApplication.GetPrivacy();
            ViewData["province"] = _cookieHelper.Get("province");
            return View("Privacy", privacy);
        }

        [ActionName("درباره-اُکاپیا")]
        public IActionResult About()
        {
            var about = _settingApplication.GetSettings();
            ViewData["province"] = _cookieHelper.Get("province");
            return View("About", about);
        }

        [ActionName("تماس-با-اُکاپیا")]
        public IActionResult Contact()
        {
            var contact = _settingApplication.GetSettings();
            ViewData["province"] = _cookieHelper.Get("province");
            return View("Contact", contact);
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

        [HttpGet]
        public ActionResult GetModals()
        {
            if (_authHelper.GetCurrnetUserInfo().Role != 1) return Json("");
            var userId = _authHelper.GetCurrnetUserInfo().ReferenceRecordId;
            var modals = _modalApplication.GetUserModals(userId);
            return PartialView("_Modal", modals);
        }

        [HttpPost]
        public ActionResult Contactus(CreateContact command)
        {
            var result = _contactApplication.Create(command);
            ViewData["Message"] = result.Message;
            var contact = _settingApplication.GetSettings();
            return View("Contact", contact);
        }
    }
}