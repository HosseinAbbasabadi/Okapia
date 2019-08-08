using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.SeachModels;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class CommentController : Controller
    {
        private readonly ICommentApplication _commentApplication;

        public CommentController(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public ActionResult Index(CommentSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 40;
            }

            var comments = _commentApplication.Search(searchModel, out int recordCount);
            var commentIndex = new CommentIndexViewModel
            {
                CommentSearchModel = searchModel,
                CommentViewModels = comments
            };
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(commentIndex);
        }

        public ActionResult ListContent(CommentSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 40;
            }

            var jobRequests = _commentApplication.Search(searchModel, out var recordCount);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return PartialView("_ListComments", jobRequests);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        //public JsonResult ChangeStatus(ChangeStatus command)
        //{
        //    var result = _commentApplication.ChangeStatus(command);
        //    return Json(result);
        //}

        //public ActionResult RegisterJobRequestToJob(long id)
        //{
        //    var jobRequest = _jobRequestApplication.GetJobRequest(id);
        //    var createJob = new CreateJob
        //    {
        //        JobName = jobRequest.Name,
        //        JobContactTitile = jobRequest.ContactTitle,
        //        JobAddress = jobRequest.Address,
        //        JobMobile1 = jobRequest.Mobile,
        //        JobTel1 = jobRequest.Tel,
        //        JobProvienceId = jobRequest.ProvinceId,
        //        JobCityId = jobRequest.CityId,
        //        Content = jobRequest.Description,
        //        Proviences = new SelectList(Provinces.ToList(), "Id", "Name"),
        //        JobRequestId = id,
        //        Categories = new SelectList(_categoryApplication.GetCategories(), "CategoryId", "CategoryName")
        //    };
        //    return View("~/Areas/Administrator/Views/Job/Create.cshtml", createJob);
        //}
    }
}