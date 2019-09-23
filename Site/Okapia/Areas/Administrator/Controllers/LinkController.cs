using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Link;
using Okapia.Domain.SeachModels;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class LinkController : Controller
    {
        private readonly ILinkApplication _linkApplication;
        private readonly ILinkGroupApplication _linkGroupApplication;

        public LinkController(ILinkApplication linkApplication, ILinkGroupApplication linkGroupApplication)
        {
            _linkApplication = linkApplication;
            _linkGroupApplication = linkGroupApplication;
        }

        // GET: Link
        public ActionResult Index(LinkSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var links = _linkApplication.Search(searchModel, out var recordCount);
            searchModel.LinkGroups = new SelectList(_linkGroupApplication.GetActiveLinkGroups(), "Id", "Name");
            var linkIndex = new LinkIndexViewModel {LinkSearchModel = searchModel, LinkViewModels = links};
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(linkIndex);
        }

        public ActionResult ListContent(LinkSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var links = _linkApplication.Search(searchModel, out var recordCount);
            searchModel.LinkGroups = new SelectList(_linkGroupApplication.GetActiveLinkGroups(), "Id", "Name");
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return PartialView("_ListLink", links);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            var createLink = new CreateLink
            {
                LinkGroups = new SelectList(_linkGroupApplication.GetActiveLinkGroups(), "Id", "Name")
            };
            return PartialView("_Create", createLink);
        }

        // POST: City/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create(CreateLink command)
        {
            var result = _linkApplication.Create(command);
            return Json(result);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            var link = _linkApplication.GetLinkDetails(id);
            link.LinkGroups = new SelectList(_linkGroupApplication.GetActiveLinkGroups(), "Id", "Name");
            return PartialView("_Edit", link);
        }

        // POST: City/Edit/5
        [HttpPost]
        public JsonResult Edit(int id, EditLink command)
        {
            command.Id = id;
            var result = _linkApplication.Update(command);
            return Json(result);
        }

        // POST: City/Delete/5
        public ActionResult Delete(int id)
        {
            _linkApplication.Delete(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public ActionResult Activate(int id)
        {
            _linkApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }
    }
}