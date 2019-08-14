using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Areas.Administrator.Controllers;
using Okapia.Domain.Commands.Comment;
using Okapia.Domain.SeachModels;
using Okapia.Models;

namespace Okapia.Controllers
{
    public class JobViewController : Controller
    {
        private readonly IJobApplication _jobApplication;
        private readonly ICommentApplication _commentApplication;
        private readonly ICategoryApplication _categoryApplication;

        public JobViewController(IJobApplication jobApplication, ICityApplication cityApplication,
            ICommentApplication commentApplication, ICategoryApplication categoryApplication)
        {
            _jobApplication = jobApplication;
            _commentApplication = commentApplication;
            _categoryApplication = categoryApplication;
        }

        public ActionResult Index(JobViewSearchModel searchModel)
        {
            var jobs = _jobApplication.GetJobsForCategoryView(searchModel);
            searchModel.Categories =
                new SelectList(_categoryApplication.GetCategoriesForSearch(), "CategoryId", "CategoryName");
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            var jobIndex = new JobViewIndexViewModel
            {
                JobViewSearchModel = searchModel,
                JobItemViewModels = jobs
            };

            return View(jobIndex);
        }

        // GET: Job/Details/5
        public ActionResult Details(int id)
        {
            var jobDetails = _jobApplication.GetJobViewDetails(id);
            var index = new DetailsIndexViewModel
            {
                JobViewDetailsViewModel = jobDetails,
                AddComment = new AddComment()
            };
            return View(index);
        }

        public ActionResult AddComment(AddComment command)
        {
            command.CommentOwner = "Job";
            var result = _commentApplication.Create(command);
            if (result.Success)
                return RedirectToAction("Details", new {id = command.CommentOwnerRecordId});
            ViewData["errorMessage"] = result.Message;
            return RedirectToAction("Details", new {id = command.CommentOwnerRecordId});
        }
    }
}