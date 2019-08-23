using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Category;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Category;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class CategoryController : Controller
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        // GET: Category
        public ActionResult Index(CategorySearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 20;
            }

            var categories = _categoryApplication.Search(searchModel, out var recordCount).ToList();
            var categorySearchModel = ProvideCategorySearchModel(searchModel);
            var categoryIndex = ProviceCategoryIndex(categorySearchModel, categories);
            Pager.PreparePager(categorySearchModel, recordCount);
            ViewData["searchModel"] = categorySearchModel;
            return View(categoryIndex);
        }

        private CategorySearchModel ProvideCategorySearchModel(CategorySearchModel searchModel)
        {
            searchModel.Categories = new SelectList(_categoryApplication.GetParentCategories(), "CategoryId", "CategoryName");
            return searchModel;
        }

        private static CategoryIndexViewModel ProviceCategoryIndex(CategorySearchModel categorySearchModel,
            IEnumerable<CategoryViewModel> categories)
        {
            return new CategoryIndexViewModel
            {
                CategorySearchModel = categorySearchModel,
                CategoryViewModels = categories
            };
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var createModel = new CreateCategory
            {
                Categories = new SelectList(_categoryApplication.GetParentCategories(), "CategoryId", "CategoryName")
            };
            return View(createModel);
        }

        // POST: Category/Create
        [HttpPost]
        public JsonResult Create(CreateCategory command)
        {
            var result = _categoryApplication.Create(command);
            return Json(result);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id, [FromQuery(Name = "redirectUrl")] string redirectUrl)
        {
            var category = _categoryApplication.GetCategoryDetails(id);
            var categories = _categoryApplication.GetParentCategories().Where(x => x.CategoryId != id);
            category.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            ViewData["redirectUrl"] = redirectUrl;
            return View(category);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(int id, EditCategory command)
        {
            command.CategoryId = id;
            var result = _categoryApplication.Update(command);
            return Json(result);
        }

        public ActionResult Delete(int id)
        {
            _categoryApplication.Delete(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public ActionResult Activate(int id)
        {
            _categoryApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public JsonResult CheckSlugDuplication(string id)
        {
            var result = _categoryApplication.CheckSlugDuplication(id);
            return Json(result);
        }
    }
}