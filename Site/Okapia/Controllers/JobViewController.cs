using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Areas.Administrator.Controllers;
using Okapia.Domain.Commands.Comment;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;
using Okapia.Models;

namespace Okapia.Controllers
{
    //[ResponseCache(CacheProfileName = "Default")]
    public class JobViewController : Controller
    {
        private readonly IJobApplication _jobApplication;
        private readonly ICommentApplication _commentApplication;
        private readonly ICategoryApplication _categoryApplication;
        private readonly ICookieHelper _cookieHelper;

        public JobViewController(IJobApplication jobApplication, ICityApplication cityApplication,
            ICommentApplication commentApplication, ICategoryApplication categoryApplication,
            IHostingEnvironment environment, ICookieHelper cookieHelper)
        {
            _jobApplication = jobApplication;
            _commentApplication = commentApplication;
            _categoryApplication = categoryApplication;
            _cookieHelper = cookieHelper;
        }

        [ActionName("مراکز-خدماتی-و-فروشگاهی")]
        public ActionResult Index(JobViewSearchModel searchModel)
        {
            searchModel.Categories =
                new SelectList(_categoryApplication.GetCategoriesForSearch(), "CategoryId", "CategoryName");
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            var category =_categoryApplication.GetCategoryViewDetails(searchModel.CategoryId, searchModel.Province);
            var jobIndex = new JobViewIndexViewModel
            {
                JobViewSearchModel = searchModel,
                CategoryViewDetailsViewModel = category
            };
            ViewData["province"] = searchModel.Province;
            return View("Index", jobIndex);
        }

        public ActionResult GetJobsByCategoryId(int id, string color, string province)
        {
            var jobs = _jobApplication.GetJobsByCategoryId(id, province);
            ViewData["Color"] = color;
            return PartialView("_Jobs", jobs);
        }

        public ActionResult Details(string id)
        {
            var jobDetails = _jobApplication.GetJobViewDetails(id);
            var index = new JobDetailsIndexViewModel
            {
                JobViewDetailsViewModel = jobDetails,
                AddComment = new AddComment()
            };
            ViewData["province"] = _cookieHelper.Get("province");
            return View(index);
        }

        public ActionResult AddComment(AddComment command)
        {
            command.CommentOwner = "Job";
            var result = _commentApplication.Create(command);
            if (result.Success)
                return RedirectToAction("Details", new {id = command.CommentOwnerRecordSlug});
            ViewData["errorMessage"] = result.Message;
            return RedirectToAction("Details", new {id = command.CommentOwnerRecordSlug});
        }

        [HttpPost]
        public JsonResult Search(string phrase, string province)
        {
            var jobs = _jobApplication.Search(phrase, province);
            jobs.ForEach(job =>
            {
                job.JobUrl = Url.Action("Details", "JobView", new {id = job.JobSlug});
                job.JobPictureUrl = "/JobPhotos/Thumbs/" + job.JobPicture;
            });

            jobs.Add(new JobSearchResultViewModel
            {
                JobName = "بیشتر",
                JobUrl = Url.Action("SearchResult", "JobView", new {q = phrase, pn = province})
            });
            return Json(jobs);
        }

        public ActionResult SearchResult(string q, string pn)
        {
            var jobs = _jobApplication.SearchResult(q, pn);
            ViewData["Phrase"] = q;
            ViewData["province"] = _cookieHelper.Get("province");
            return View(jobs);
        }
    }
}