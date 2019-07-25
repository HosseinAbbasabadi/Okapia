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
            var marketerDetails = _marketerApplication.GetMarketerDetails(id);
            marketerDetails.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            return PartialView("_Edit", marketerDetails);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(int id, EditMarketer command)
        {
            command.MarketerId = id;
            var result = _marketerApplication.Edit(command);
            return Json(result);
        }

        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var result = _marketerApplication.Delete(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }


        public ActionResult Activate(long id)
        {
            var result = _marketerApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }
    }
}