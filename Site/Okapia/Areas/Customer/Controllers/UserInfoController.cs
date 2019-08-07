using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Areas.Administrator.Controllers;
using Okapia.Domain.Commands.User;

namespace Okapia.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "1")]
    public class UserInfoController : Controller
    {
        private readonly IUserApplication _userApplication;
        private readonly IAuthHelper _authHelper;

        public UserInfoController(IUserApplication userApplication, IAuthHelper authHelper)
        {
            _userApplication = userApplication;
            _authHelper = authHelper;
        }

        // GET: UserInfo
        public ActionResult Index()
        {
            var userId = _authHelper.GetCurrnetUserInfo().ReferenceRecordId;
            var user = _userApplication.GetUserInfo(userId);
            return View(user);
        }

        // GET: UserInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserInfo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(long id, [FromQuery(Name = "redirectUrl")] string redirectUrl)
        {
            var userDetails = _userApplication.GetUserDetails(id);
            userDetails.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            ViewData["redirectUrl"] = redirectUrl;
            return View("Edit", userDetails);
        }

        // POST: UserInfo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(long id, EditUser command)
        {
            command.Id = id;
            var result = _userApplication.EditByUser(command);
            return Json(result);
        }

        // GET: UserInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserInfo/Delete/5
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