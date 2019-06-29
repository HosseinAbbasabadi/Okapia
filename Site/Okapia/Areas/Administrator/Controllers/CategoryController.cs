using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Commands.Category;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Category;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
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

            var categories = _categoryApplication.GetCategoriesForList(searchModel, out int recordCount).ToList();
            var categorySearchModel = ProvideCategorySearchModel(searchModel, categories);
            var categoryIndex = ProviceCategoryIndex(categorySearchModel, categories);
            Pager.PreparePager(categorySearchModel, recordCount);
            ViewData["searchModel"] = categorySearchModel;
            return View(categoryIndex);
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

        private CategorySearchModel ProvideCategorySearchModel(CategorySearchModel searchModel,
            IEnumerable<CategoryViewModel> categories)
        {
            searchModel.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return searchModel;
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var createModel = new CreateCategory {Categories = new SelectList(_categoryApplication.GetCategories(), "CategoryId", "CategoryName")};
            return View(createModel);
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}