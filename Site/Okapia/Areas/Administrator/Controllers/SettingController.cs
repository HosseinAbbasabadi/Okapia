using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Domain.Commands.Setting;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class SettingController : Controller
    {
        private readonly ISettingApplication _settingApplication;

        public SettingController(ISettingApplication settingApplication)
        {
            _settingApplication = settingApplication;
        }

        public ActionResult Index()
        {
            var settings = _settingApplication.GetSettings();
            return View(settings);
        }
        
        public ActionResult Create()
        {
            var settings = _settingApplication.GetSettings();
            return View(settings);
        }

        [HttpPost]
        public JsonResult Create(SettingDto command)
        {
            var result = _settingApplication.CreateSettings(command);
            return Json(result);
        }
    }
}