using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.City;
using Okapia.Domain.Commands.LinkGroup;
using Okapia.Domain.SeachModels;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class LinkGroupController : Controller
    {
        private readonly ILinkGroupApplication _linkGroupApplication;

        public LinkGroupController(ILinkGroupApplication linkGroupApplication)
        {
            _linkGroupApplication = linkGroupApplication;
        }

        public ActionResult Index(LinkGroupSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var linkGroups = _linkGroupApplication.Search(searchModel, out var recordCount);
            var linkGroupIndex =
                new LinkGroupIndexViewModel {LinkGroupSearchModel = searchModel, LinkGroupViewModels = linkGroups};
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(linkGroupIndex);
        }

        public ActionResult ListContent(LinkGroupSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var linkGroups = _linkGroupApplication.Search(searchModel, out var recordCount);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return PartialView("_ListLinkGroups", linkGroups);
        }

        public ActionResult Create()
        {
            var createLinkGroup = new CreateLinkGroup();
            return PartialView("_Create", createLinkGroup);
        }

        [HttpPost]
        public JsonResult Create(CreateLinkGroup command)
        {
            var result = _linkGroupApplication.Create(command);
            return Json(result);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            var LinkGroup = _linkGroupApplication.GetLinkGroupDetails(id);
            return PartialView("_Edit", LinkGroup);
        }

        // POST: City/Edit/5
        [HttpPost]
        public JsonResult Edit(int id, EditLinkGroup command)
        {
            command.Id = id;
            var result = _linkGroupApplication.Edit(command);
            return Json(result);
        }

        // POST: City/Delete/5
        public ActionResult Delete(int id)
        {
            _linkGroupApplication.Delete(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public ActionResult Activate(int id)
        {
            _linkGroupApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }
    }
}