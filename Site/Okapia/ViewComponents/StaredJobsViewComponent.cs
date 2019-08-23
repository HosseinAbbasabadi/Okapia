using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class StaredJobsViewComponent : ViewComponent
    {
        private readonly IJobApplication _jobApplication;

        public StaredJobsViewComponent(IJobApplication jobApplication)
        {
            _jobApplication = jobApplication;
        }

        public ViewViewComponentResult Invoke()
        {
            var jobs = _jobApplication.GetStaredJobsForLandingPage();
            return View("_StaredJobs", jobs);
        }
    }
}