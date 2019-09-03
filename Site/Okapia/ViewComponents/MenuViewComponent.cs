using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Models;

namespace Okapia.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ICategoryApplication _categoryApplication;

        public MenuViewComponent(IAuthHelper authHelper, ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryApplication.GetCategoriesForMenu();
            return View("Default", categories);
        }
    }
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
