using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class CompanyNumbersViewComponent : ViewComponent
    {
        private readonly ISettingApplication _settingApplication;

        public CompanyNumbersViewComponent(ISettingApplication settingApplication)
        {
            _settingApplication = settingApplication;
        }

        public IViewComponentResult Invoke()
        {
            var numbers = _settingApplication.GetCompanyNumbers();
            return View("_CompanyNumbers", numbers);
        }
    }
}