using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Modal;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Group;
using Okapia.Domain.ViewModels.Modal;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class ModalController : Controller
    {
        private readonly IModalApplication _modalApplication;
        private readonly IGroupApplication _groupApplication;

        public ModalController(IModalApplication modalApplication, IGroupApplication groupApplication)
        {
            _modalApplication = modalApplication;
            _groupApplication = groupApplication;
        }

        // GET: Notification
        public ActionResult Index(ModalSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 20;
            }

            var modals = _modalApplication.Search(searchModel, out var recordCount).ToList();
            var groups = _groupApplication.GetGroups();
            var modalSearchModel = ProvideCategorySearchModel(searchModel, groups);
            var modalIndexViewModel = ProviceCategoryIndex(modalSearchModel, modals);
            Pager.PreparePager(modalSearchModel, recordCount);
            ViewData["searchModel"] = modalSearchModel;
            return View(modalIndexViewModel);
        }

        private static ModalSearchModel ProvideCategorySearchModel(ModalSearchModel searchModel,
            IEnumerable<GroupViewModel> groups)
        {
            searchModel.Groups = new SelectList(groups, "Id", "Name");
            return searchModel;
        }

        private static ModalIndexViewModel ProviceCategoryIndex(ModalSearchModel modalSearchModel,
            List<ModalViewModel> modals)
        {
            return new ModalIndexViewModel
            {
                ModalSearchModel = modalSearchModel,
                ModalViewModels = modals
            };
        }

        // GET: Notification/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Notification/Create
        public ActionResult Create()
        {
            var createModal = new CreateModal
            {
                Groups = new SelectList(_groupApplication.GetGroups(), "Id", "Name")
            };
            return View(createModal);
        }

        // POST: Notification/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create(CreateModal command)
        {
            var result = _modalApplication.Create(command);
            return Json(result);
        }

        // GET: Notification/Edit/5
        public ActionResult Edit(int id, [FromQuery(Name = "redirectUrl")] string redirectUrl)
        { 
            var editModal = _modalApplication.GetModalDetails(id);
            editModal.Groups = new SelectList(_groupApplication.GetGroups(), "Id", "Name");
            ViewData["redirectUrl"] = redirectUrl;
            return View(editModal);
        }

        // POST: Notification/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(int id, EditModal command)
        {
            command.Id = id;
            var result = _modalApplication.Edit(command);
            return Json(result);
        }

        // POST: Notification/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _modalApplication.Delete(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }
        
        // POST: Notification/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Activate(int id)
        {
            _modalApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }
    }
}