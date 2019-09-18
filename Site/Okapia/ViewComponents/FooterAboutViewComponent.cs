using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class FooterAboutViewComponent : ViewComponent
    {
        private readonly ISettingApplication _settingApplication;
        public FooterAboutViewComponent(ISettingApplication settingApplication)
        {
            _settingApplication = settingApplication;
        }

        public IViewComponentResult Invoke()
        {
            var settings = _settingApplication.GetSettings();
            return View("_FooterAbout", settings);
        }
    }
}