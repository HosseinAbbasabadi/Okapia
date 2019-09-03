using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Job;
using Okapia.Domain.Commands.JobRequest;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.JobRequest;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class JobRequestController : Controller
    {
        private readonly IJobRequestApplication _jobRequestApplication;
        private readonly ICategoryApplication _categoryApplication;

        public JobRequestController(IJobRequestApplication jobRequestApplication, ICategoryApplication categoryApplication)
        {
            _jobRequestApplication = jobRequestApplication;
            _categoryApplication = categoryApplication;
        }

        public ActionResult Index(JobRequestSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 40;
            }

            var jobRequests = _jobRequestApplication.Search(searchModel, out int recordCount);
            //var employeeSearchModel = ProvideCategorySearchModel(searchModel, categories);
            var jobRequestIndex = ProviceEmployeeIndex(searchModel, jobRequests);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(jobRequestIndex);
        }

        private static JobRequestIndexViewModel ProviceEmployeeIndex(JobRequestSearchModel categorySearchModel,
            List<JobRequestViewModel> categories)
        {
            categorySearchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            return new JobRequestIndexViewModel
            {
                JobRequestSearchModel = categorySearchModel,
                JobRequestViewModels = categories
            };
        }

        public ActionResult ListContent(JobRequestSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 40;
            }

            var jobRequests = _jobRequestApplication.Search(searchModel, out var recordCount);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return PartialView("_ListRequests", jobRequests);
        }

        public ActionResult Details(long id)
        {
            var result = _jobRequestApplication.GetJobRequestDetails(id);
            return PartialView("_JobRequestDetails", result);
        }

        public JsonResult ChangeStatus(ChangeStatus command)
        {
            var result = _jobRequestApplication.ChangeStatus(command);
            return Json(result);
        }

        public ActionResult RegisterJobRequestToJob(long id)
        {
            var jobRequest = _jobRequestApplication.GetJobRequest(id);
            var changeStatus = new ChangeStatus
            {
                Id = id,
                Status = Constants.Statuses.Registered.Id
            };
            var createJob = new CreateJob
            {
                JobName = jobRequest.Name,
                JobContactTitile = jobRequest.ContactTitle,
                JobAddress = jobRequest.Address,
                JobMobile1 = jobRequest.Mobile,
                JobTel1 = jobRequest.Tel,
                JobProvienceId = jobRequest.ProvinceId,
                JobCityId = jobRequest.CityId,
                Content = jobRequest.Description,
                Proviences = new SelectList(Provinces.ToList(), "Id", "Name"),
                JobRequestId = id,
                Categories = new SelectList(_categoryApplication.GetChildCategories(), "CategoryId", "CategoryName")
            };
            return View("~/Areas/Administrator/Views/Job/Create.cshtml", createJob);
        }
    }
}