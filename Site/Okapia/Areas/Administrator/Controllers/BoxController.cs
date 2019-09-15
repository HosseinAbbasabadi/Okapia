using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Box;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Box;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class BoxController : Controller
    {
        private readonly IBoxApplication _boxApplication;

        public BoxController(IBoxApplication boxApplication)
        {
            _boxApplication = boxApplication;
        }

        public ActionResult Index(BoxSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 20;
            }

            var categories = _boxApplication.Search(searchModel, out var recordCount);
            var categoryIndex = ProviceBoxIndex(searchModel, categories);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(categoryIndex);
        }


        private static BoxIndexViewModel ProviceBoxIndex(BoxSearchModel boxSearchModel,
            List<BoxViewModel> boxes)
        {
            return new BoxIndexViewModel
            {
                BoxSearchModel = boxSearchModel,
                BoxViewModels = boxes
            };
        }

        public ActionResult Create()
        {
            var createBox = new CreateBox();
            return View(createBox);
        }

        [HttpPost]
        public JsonResult Create(CreateBox command)
        {
            var result = _boxApplication.Create(command);
            return Json(result);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Box/Delete/5
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