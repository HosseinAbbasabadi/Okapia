using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Category;
using Okapia.Domain.Commands.PageCategory;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.PageCategory;
using Okapia.Helpers;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class PageCategoryController : Controller
    {
        private readonly IEmployeeApplication _employeeApplication;
        private readonly IPageCategoryApplication _pageCategoryApplication;

        public PageCategoryController(IPageCategoryApplication pageCategoryApplication,
            IEmployeeApplication employeeApplication)
        {
            _pageCategoryApplication = pageCategoryApplication;
            _employeeApplication = employeeApplication;
        }

        // GET: Category
        public ActionResult Index(PageCategorySearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 20;
            }

            var pages = _pageCategoryApplication.Search(searchModel, out var recordCount).ToList();
            searchModel.Categories = new SelectList(_pageCategoryApplication.GetPageCategories(), "PageCategoryId",
                "PageCategoryName");
            searchModel.Employees =
                new SelectList(_employeeApplication.GetEmployees(), "EmployeeId", "EmployeeFullname");
            var pageCategoryIndex = ProviceCategoryIndex(searchModel, pages);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(pageCategoryIndex);
        }

        private static PageCategoryIndexViewModel ProviceCategoryIndex(PageCategorySearchModel categorySearchModel,
            List<PageCategoryViewModel> pageCategories)
        {
            return new PageCategoryIndexViewModel
            {
                PageCategorySearchModel = categorySearchModel,
                PageCategoryViewModels = pageCategories
            };
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var createPageCategory = new CreatePageCategory
            {
                PageCategories = new SelectList(_pageCategoryApplication.GetPageCategories(), "PageCategoryId",
                    "PageCategoryName")
            };
            return View(createPageCategory);
        }

        [HttpPost]
        public JsonResult Create(CreatePageCategory command)
        {
            var result = _pageCategoryApplication.Create(command);
            return Json(result);
        }

        public ActionResult Edit(int id, [FromQuery(Name = "redirectUrl")] string redirectUrl)
        {
            var pageCategory = _pageCategoryApplication.GetPageCategoryDetails(id);
            pageCategory.PageCategories = new SelectList(_pageCategoryApplication.GetPageCategories().Where(x=>x.PageCategoryId != id), "PageCategoryId",
                "PageCategoryName");
            ViewData["redirectUrl"] = redirectUrl;
            return View(pageCategory);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(int id, EditPageCategory command)
        {
            command.PageCategoryId = id;
            var result = _pageCategoryApplication.Edit(command);
            return Json(result);
        }

        public ActionResult Delete(int id)
        {
            _pageCategoryApplication.Delete(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public ActionResult Activate(int id)
        {
            _pageCategoryApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public JsonResult CheckSlugDuplication(string id)
        {
            var result = _pageCategoryApplication.CheckSlugDuplication(id);
            return Json(result);
        }
    }
}