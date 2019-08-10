using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Areas.Administrator.Controllers;
using Okapia.Domain.Commands;
using Okapia.Domain.Commands.User;

namespace Okapia.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthHelper _authHelper;
        private readonly IAccountApplication _accountApplication;

        public AccountController(IAccountApplication accountApplication, IAuthHelper authHelper)
        {
            _accountApplication = accountApplication;
            _authHelper = authHelper;
        }

        public ActionResult Register()
        {
            if (_authHelper.GetCurrnetUserInfo().IsAuthorized) return RedirectToAction("Index", "Home");
            var createUser = new CreateUser
            {
                Provinces = new SelectList(Provinces.ToList(), "Id", "Name")
            };
            return View(createUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CreateUser createUser)
        {
            if (!ModelState.IsValid) return View("Register", createUser);
            var result = _accountApplication.Register(createUser);
            if (result.Success)
                return RedirectToAction("Login", "Account");
            ViewData["errorMessage"] = result.Message;
            createUser.ProvinceId = 0;
            createUser.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            return View(createUser);
        }

        public ActionResult Login()
        {
            if (_authHelper.GetCurrnetUserInfo().IsAuthorized) return RedirectToAction("Index", "Home");
            var login = new Login();
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (!ModelState.IsValid) return View("Login", login);
            var result = _accountApplication.Login(login);
            if (result.Success)
            {
                if (result.RecordId == 5 || result.RecordId == 4)
                    return RedirectToAction("Index", "Home", new {area = "Administrator"});
                if (result.RecordId == 3)
                    return RedirectToAction("Index", "Home", new {area = "Club"});
                if (result.RecordId == 2)
                    return RedirectToAction("Index", "Home", new {area = "Job"});
                if (result.RecordId == 1)
                    return RedirectToAction("Index", "Home", new {area = "Customer"});
            }

            ViewData["errorMessage"] = result.Message;
            return View(login);
        }

        public ActionResult Logout()
        {
            _accountApplication.LogoutUser();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }


        public ActionResult ChnagePassword(long id)
        {
            var model = new ChangePassword();
            ViewData["accountId"] = id;
            return PartialView("_ChangePassword", model);
        }

        [HttpPost]
        public JsonResult ChangePassword(long id, ChangePassword command)
        {
            command.AccountId = id;
            var result = _accountApplication.ChangePassword(command);
            return Json(result);
        }
    }
}