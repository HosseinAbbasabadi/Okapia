using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Marketer;
using Okapia.Domain.SeachModels;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class MarketerController : Controller
    {
        private readonly IMarketerApplication _marketerApplication;

        public MarketerController(IMarketerApplication marketerApplication)
        {
            _marketerApplication = marketerApplication;
        }

        // GET: Marketer
        public ActionResult Index(MarketerSearchModel searchModel)
        {
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var marketers = _marketerApplication.Search(searchModel, out var recordCount);
            var marketerIndex =
                new MarketerIndexViewModel {MarketerSearchModel = searchModel, MarketerViewModels = marketers};
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(marketerIndex);
        }

        public ActionResult ListContent(MarketerSearchModel searchModel)
        {
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var marketers = _marketerApplication.Search(searchModel, out var recordCount);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return PartialView("_ListMarketers", marketers);
        }
        
        // GET: Marketer/Create
        public ActionResult Create()
        {
            var createMarketer = new CreateMarketer
            {
                Provinces = new SelectList(Provinces.ToList(), "Id", "Name")
            };
            return PartialView("_Create", createMarketer);
        }

        // POST: Marketer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMarketer command)
        {
            var result = _marketerApplication.Create(command);
            return Json(result);
        }

        // GET: Marketer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Marketer/Edit/5
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

        // GET: Marketer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Marketer/Delete/5
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


        public JsonResult Activate(long id)
        {
            return Json("");
        }
    }
}