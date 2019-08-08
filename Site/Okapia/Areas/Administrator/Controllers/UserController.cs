using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.User;
using Okapia.Domain.SeachModels;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class UserController : Controller
    {
        private readonly IUserApplication _userApplication;
        private readonly IAccountApplication _accountApplication;
        private readonly IGroupApplication _groupApplication;

        public UserController(IUserApplication userApplication, IAccountApplication accountApplication,
            IGroupApplication groupApplication)
        {
            _userApplication = userApplication;
            _accountApplication = accountApplication;
            _groupApplication = groupApplication;
        }

        public ActionResult Index(UserSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 20;
            }

            var users = _userApplication.Search(searchModel, out var recordCount);
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            searchModel.Groups = new SelectList(_groupApplication.GetGroups(), "Id", "Name");
            var userIndexViewModel = new UserIndexViewModel
            {
                UserSearchModel = searchModel,
                UserViewModels = users
            };
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(userIndexViewModel);
        }

        public ActionResult ListContent(UserSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 20;
            }

            var users = _userApplication.Search(searchModel, out var recordCount);
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            searchModel.Groups = new SelectList(_groupApplication.GetGroups(), "Id", "Name");
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View("_ListUsers", users);
        }

        public ActionResult Create()
        {
            var createUser = new CreateUser
            {
                Provinces = new SelectList(Provinces.ToList(), "Id", "Name")
            };
            return View("Create", createUser);
        }

        [HttpPost]
        public JsonResult Create(CreateUser command)
        {
            var result = _userApplication.Create(command);
            return Json(result);
        }

        public ActionResult Edit(long id, [FromQuery(Name = "redirectUrl")] string redirectUrl)
        {
            var userDetails = _userApplication.GetUserDetails(id);
            userDetails.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            ViewData["redirectUrl"] = redirectUrl;
            return View("Edit", userDetails);
        }


        [HttpPost]
        public JsonResult Edit(long id, EditUser command)
        {
            command.Id = id;
            var result = _userApplication.Edit(command);
            return Json(result);
        }

        public JsonResult Delete(int id)
        {
            var result = _accountApplication.Delete(id);
            //var referer = Request.Headers["Referer"].ToString();
            return Json(result);
        }

        public ActionResult Activate(long id)
        {
            _accountApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public ActionResult SendToGroup()
        {
            var sendToGroup = new SendToGroup
            {
                Groups = new SelectList(_groupApplication.GetGroups(), "Id", "Name")
            };
            return PartialView("_SendToGroup", sendToGroup);
        }

        [HttpPost]
        public JsonResult SendToGroup(int id, UserSearchModel searchModel)
        {
            var result = _groupApplication.AddUsersToGroup(id, searchModel);
            return Json(result);
        }
    }
}