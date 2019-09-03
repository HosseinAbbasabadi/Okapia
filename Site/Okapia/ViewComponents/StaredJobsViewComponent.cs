using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class StaredJobsViewComponent : ViewComponent
    {
        private readonly IJobApplication _jobApplication;
        private readonly ISettingApplication _settingApplication;

        public StaredJobsViewComponent(IJobApplication jobApplication, ISettingApplication settingApplication)
        {
            _jobApplication = jobApplication;
            _settingApplication = settingApplication;
        }

        public ViewViewComponentResult Invoke()
        {
            var jobs = _jobApplication.GetStaredJobsForLandingPage();
            var setting = _settingApplication.GetSettings();
            ViewData["title"] = setting.FeaturedJobsTitle;
            return View("_StaredJobs", jobs);
        }
    }
}