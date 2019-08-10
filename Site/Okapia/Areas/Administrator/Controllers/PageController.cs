using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Page;
using Okapia.Domain.SeachModels;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class PageController : Controller
    {
        private readonly IPageApplication _pageApplication;
        private readonly IEmployeeApplication _employeeApplication;
        private readonly IPageCategoryApplication _pageCategoryApplication;

        public PageController(IPageApplication pageApplication, IPageCategoryApplication pageCategoryApplication,
            IEmployeeApplication employeeApplication)
        {
            _pageApplication = pageApplication;
            _pageCategoryApplication = pageCategoryApplication;
            _employeeApplication = employeeApplication;
        }

        public ActionResult Index(PageSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 20;
            }

            var pages = _pageApplication.Search(searchModel, out var recordCount);
            searchModel.Categories = new SelectList(_pageCategoryApplication.GetPageCategories(), "PageCategoryId",
                "PageCategoryName");
            searchModel.Employees =
                new SelectList(_employeeApplication.GetEmployees(), "EmployeeId", "EmployeeFullname");
            var pageIndexViewModel = new PageIndexViewModel
            {
                PageSearchModel = searchModel,
                PageViewModels = pages
            };
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(pageIndexViewModel);
        }

        public ActionResult Create()
        {
            var createPage = new CreatePage
            {
                PageCategories = new SelectList(_pageCategoryApplication.GetPageCategories(), "PageCategoryId",
                    "PageCategoryName"),
                Employees = new SelectList(_employeeApplication.GetEmployees(), "EmployeeId", "EmployeeFullname")
            };
            return View(createPage);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create(CreatePage command)
        {
            var result = _pageApplication.Create(command);
            return Json(result);
        }

        // GET: Page/Edit/5
        public ActionResult Edit(int id, [FromQuery(Name = "redirectUrl")] string redirectUrl)
        {
            var pageDetails = _pageApplication.GetPageDetails(id);
            pageDetails.PageCategories = new SelectList(_pageCategoryApplication.GetPageCategories(), "PageCategoryId",
                "PageCategoryName");
            pageDetails.Employees =
                new SelectList(_employeeApplication.GetEmployees(), "EmployeeId", "EmployeeFullname");
            ViewData["redirectUrl"] = redirectUrl;
            return View(pageDetails);
        }

        // POST: Page/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(long id, EditPage command)
        {
            command.PageId = id;
            var result = _pageApplication.Edit(command);
            return Json(result);
        }

        // GET: Page/Delete/5
        public ActionResult Delete(long id)
        {
            var result = _pageApplication.Delete(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public ActionResult Activate(long id)
        {
            var result = _pageApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public JsonResult CheckSlugDuplication(string id)
        {
            var result = _pageApplication.CheckSlugDuplication(id);
            return Json(result);
        }
    }
}