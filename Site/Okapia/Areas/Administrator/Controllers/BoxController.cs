using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Box;
using Okapia.Domain.Commands.Job;
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
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
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
            var createBox = new CreateBox {Provinces = new SelectList(Provinces.ToList(), "Id", "Name")};
            return View(createBox);
        }

        [HttpPost]
        public JsonResult Create(CreateBox command)
        {
            var result = _boxApplication.Create(command);
            return Json(result);
        }

        public ActionResult Edit(int id, [FromQuery(Name = "redirectUrl")] string redirectUrl)
        {
            var editBox = _boxApplication.GetDetails(id);
            editBox.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            ViewData["redirectUrl"] = redirectUrl;
            return View(editBox);
        }

        [HttpPost]
        public JsonResult Edit(int id, EditBox command)
        {
            command.BoxId = id;
            var result = _boxApplication.Edit(command);
            return Json(result);
        }

        public ActionResult Deactive(int id)
        {
            var result = _boxApplication.Deactive(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public ActionResult Activate(int id)
        {
            var result = _boxApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        [HttpPost]
        public ActionResult RemoveJobFromBox(AddToBox command)
        {
            var result = _boxApplication.RemoveJobFromBox(command.BoxId, command.JobId);
            return Json(result);
        }
    }
}