using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class FooterBoxesViewComponent : ViewComponent
    {
        private readonly ISettingApplication _settingApplication;
        public FooterBoxesViewComponent(ISettingApplication settingApplication)
        {
            _settingApplication = settingApplication;
        }

        public IViewComponentResult Invoke()
        {
            var fotterBoxes = _settingApplication.GetFooterBox();
            return View("_FooterBoxes", fotterBoxes);
        }
    }
}