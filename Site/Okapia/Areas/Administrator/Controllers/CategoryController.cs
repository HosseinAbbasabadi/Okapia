﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Category;
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

            var categories = _categoryApplication.Search(searchModel, out int recordCount).ToList();
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

        // GET: Category/Create
        public ActionResult Create()
        {
            var createModel = new CreateCategory
            {
                Categories = new SelectList(_categoryApplication.GetCategories(), "CategoryId", "CategoryName")
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
            var data = _categoryApplication.GetCategories();
            category.Categories = new SelectList(data, "CategoryId", "CategoryName");
            ViewData["redirectUrl"] = redirectUrl;
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(int id, EditCategory command)
        {
            command.CategoryId = id;
            var result = _categoryApplication.Update(command);
            return Json(result);
        }

        //// GET: Category/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

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
    }
}