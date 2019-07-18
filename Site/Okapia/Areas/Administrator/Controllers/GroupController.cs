using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Group;
using Okapia.Domain.SeachModels;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class GroupController : Controller
    {
        private readonly IGroupApplication _groupApplication;

        public GroupController(IGroupApplication groupApplication)
        {
            _groupApplication = groupApplication;
        }

        public ActionResult Index(GroupSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var groups = _groupApplication.Search(searchModel, out var recordCount);
            var groupIndex = new GroupIndexViewModel {GroupSearchModel = searchModel, GroupViewModels = groups};
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(groupIndex);
        }

        public ActionResult ListContent(GroupSearchModel searchModel)
        {

            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var groups = _groupApplication.Search(searchModel, out var recordCount);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return PartialView("_ListGroups", groups);
        }

        public ActionResult Create()
        {
            var createGroup = new CreateGroup();
            return PartialView("_Create", createGroup);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create(CreateGroup command)
        {
            var result = _groupApplication.Create(command);
            return Json(result);
        }

        public ActionResult Edit(int id)
        {
            var editGroup = _groupApplication.GetGroupForDetails(id);
            return PartialView("_Edit", editGroup);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(int id, EditGroup command)
        {
            command.Id = id;
            var result = _groupApplication.Edit(command);
            return Json(result);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _groupApplication.Delete(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        //[HttpPost]
        public ActionResult Activate(int id)
        {
            _groupApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }
    }
}