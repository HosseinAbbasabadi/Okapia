using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.City;
using Okapia.Domain.Commands.Faq;
using Okapia.Domain.SeachModels;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class FaqController : Controller
    {
        private readonly IFaqApplication _faqApplication;
        private readonly IJobApplication _jobApplication;

        public FaqController(IFaqApplication faqApplication, IJobApplication jobApplication)
        {
            _faqApplication = faqApplication;
            _jobApplication = jobApplication;
        }

        public ActionResult Index(FaqSearchModel searchModel)
        {
            searchModel.Jobs = new SelectList(_jobApplication.GetActiveJobs(), "JobId", "JobName");
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var faqs = _faqApplication.Search(searchModel, out var recordCount);
            var faqIndex = new FaqIndexViewModel {FaqSearchModel = searchModel, FaqViewModels = faqs};
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(faqIndex);
        }

        public ActionResult ListContent(FaqSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var faqs = _faqApplication.Search(searchModel, out var recordCount);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return PartialView("_ListFaqs", faqs);
        }

        public ActionResult Create()
        {
            var createFaq = new CreateFaq
            {
                Jobs = new SelectList(_jobApplication.GetActiveJobs(), "JobId", "JobName")
            };
            return PartialView("_Create", createFaq);
        }

        [HttpPost]
        public JsonResult Create(CreateFaq command)
        {
            var result = _faqApplication.Create(command);
            return Json(result);
        }

        public ActionResult Edit(int id)
        {
            var faq = _faqApplication.GetDetails(id);
            faq.Jobs= new SelectList(_jobApplication.GetActiveJobs(), "JobId", "JobName");
            return PartialView("_Edit", faq);
        }

        [HttpPost]
        public JsonResult Edit(int id, EditFaq command)
        {
            command.Id = id;
            var result = _faqApplication.Edit(command);
            return Json(result);
        }

        public ActionResult Delete(int id)
        {
            _faqApplication.Delete(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public ActionResult Activate(int id)
        {
            _faqApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }
    }
}