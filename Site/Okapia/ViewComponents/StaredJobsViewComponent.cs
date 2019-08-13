using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Okapia.Application.Contracts;
using Okapia.Domain.ViewModels.EmployeeController;

namespace Okapia.Areas.Administrator.ViewComponents
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