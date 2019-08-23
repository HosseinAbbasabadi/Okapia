using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Areas.Administrator.Controllers;
using Okapia.Domain.Commands.Comment;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Category;
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

        [ActionName("مراکز-خدماتی-و-فروشگاهی")]
        public ActionResult Index(JobViewSearchModel searchModel)
        {
            var jobs = _jobApplication.GetJobsForCategoryView(searchModel);
            searchModel.Categories =
                new SelectList(_categoryApplication.GetCategoriesForSearch(), "CategoryId", "CategoryName");
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            var currentCategory = _categoryApplication.GetCategoryViewDetails(searchModel.CategoryId);
            if (currentCategory == null)
            {
                currentCategory = new CategoryViewDetailsViewModel
                {
                    CategorySlug = "",
                    CategoryMetaTag = "مراکز خدماتی و فروشگاهی, اُکاپیا",
                    CategoryCanonicalAddress = "http://www.okapia.ir/JobView/مراکز-خدماتی-و-فروشگاهی",
                    CategoryMetaDesccription = "صفحه معرفی مراکز خدماتی و فروشگاهی شرکت اُکاپیا",
                    CategoryPageTittle = "مراکز خدماتی و فروشگاهی شرکت اُکاپیا",
                    CategorySeohead = "مراکز خدماتی و فروشگاهی شرکت اُکاپیا",
                };
            }
            var jobIndex = new JobViewIndexViewModel
            {
                JobViewSearchModel = searchModel,
                JobItemViewModels = jobs,
                CategoryViewDetailsViewModel = currentCategory
            };

            return View("Index", jobIndex);
        }

        // GET: Job/Details/5
        public ActionResult Details(string id)
        {
            var jobDetails = _jobApplication.GetJobViewDetails(id);
            var index = new JobDetailsIndexViewModel
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
                return RedirectToAction("Details", new {id = command.CommentOwnerRecordSlug});
            ViewData["errorMessage"] = result.Message;
            return RedirectToAction("Details", new {id = command.CommentOwnerRecordSlug});
        }
    }
}