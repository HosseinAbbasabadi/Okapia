using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Domain.QueryContracts;

namespace Okapia.ViewComponents
{
    public class MobileCategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryQuery _categoryQuery;
        private readonly ISettingApplication _settingApplication;
        public MobileCategoriesViewComponent(ICategoryQuery categoryQuery, ISettingApplication settingApplication)
        {
            _categoryQuery = categoryQuery;
            _settingApplication = settingApplication;
        }

        public IViewComponentResult Invoke(string pn)
        {
            var categories = _categoryQuery.GetCategoriesForMenu();
            ViewData["tel"] = _settingApplication.GetSettingsForView().Tell1;
            ViewData["province"] = pn;
            return View("_MobileCategories", categories);
        }
    }
}