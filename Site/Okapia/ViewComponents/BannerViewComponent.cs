using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly ISettingApplication _settingApplication;

        public BannerViewComponent(ISettingApplication settingApplication)
        {
            _settingApplication = settingApplication;
        }

        public IViewComponentResult Invoke()
        {
            var banner = _settingApplication.GetBannerInfo();
            return View("_Banner", banner);
        }
    }
}