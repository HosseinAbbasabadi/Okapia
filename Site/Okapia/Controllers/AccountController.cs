using Framework;
using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Domain.Commands;
using Okapia.Domain.Commands.User;
using Okapia.Models;

namespace Okapia.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthHelper _authHelper;
        private readonly IAccountApplication _accountApplication;

        public AccountController(IAccountApplication accountApplication, IAuthHelper authHelper,
            ICityApplication cityApplication, IDistrictApplication districtApplication,
            INeighborhoodApplication neighborhoodApplication)
        {
            _accountApplication = accountApplication;
            _authHelper = authHelper;
        }

        public ActionResult Register()
        {
            if (_authHelper.GetCurrnetUserInfo().IsAuthorized) return RedirectToAction("Index", "Home");
            var createUser = new CreateUser();
            return View(createUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CreateUser createUser)
        {
            if (!ModelState.IsValid) return View("Register", createUser);
            var result = _accountApplication.Register(createUser);
            if (result.Success)
            {
                var loginResult = _accountApplication.Login(new Login { Username = createUser.NationalCardNumber, Password = createUser.PhoneNumber });
                if (loginResult.Success)
                {
                    if (loginResult.RecordId == 5 || loginResult.RecordId == 4)
                        return RedirectToAction("Index", "Home", new { area = "Administrator" });
                    if (loginResult.RecordId == 3)
                        return RedirectToAction("Index", "Home", new { area = "Club" });
                    if (loginResult.RecordId == 2)
                        return RedirectToAction("Index", "Home", new { area = "Job" });
                    if (loginResult.RecordId == 1)
                        return RedirectToAction("Index", "Home", new { area = "Customer" });
                }
            }
            ViewData["errorMessage"] = result.Message;
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

        public ActionResult ChooseFpMethod()
        {
            var chooseFpMethod = new ChooseFpMethod();
            return View(chooseFpMethod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChooseFpMethod(ChooseFpMethod command)
        {
            var result = new OperationResult();
            if (command.Type == "sms")
            {
                result = _accountApplication.CreateVerificationCodeByMobile(command.Phonenumber);
            }

            if (command.Type == "email")
            {
                result = _accountApplication.CreateVerificationCodeByEmail(command.Email);
            }

            if (result.Success)
            {
                return RedirectToAction("VerifyVerificationCode", command);
            }

            ViewData["errorMessage"] = result.Message;
            return View(command);
        }

        public ActionResult VerifyVerificationCode(ChooseFpMethod command)
        {
            return View(command);
        }

        [HttpPost]
        public ActionResult VerifyCode(ChooseFpMethod command)
        {
            var result = new OperationResult();
            if (command.Type == "sms")
            {
                result = _accountApplication.VerifyWithSms(command.Phonenumber, command.Code);
            }

            if (command.Type == "email")
            {
                result = _accountApplication.VerifyWithEmail(command.Email, command.Code);
            }

            if (result.Success)
                return RedirectToAction("ChangePasswordPage", routeValues: new {id = result.RecordId});
            ViewData["errorMessage"] = result.Message;
            return View("VerifyVerificationCode");
        }

        [HttpGet]
        public ActionResult ChangePasswordPage(long id)
        {
            var model = new ChangePassword();
            ViewData["accountId"] = id;
            return View("ChangePassword", model);
        }

        [HttpPost]
        public ActionResult ChangePasswordPage(long id, ChangePassword command)
        {
            command.AccountId = id;
            var result = _accountApplication.ChangePassword(command);
            if (result.Success)
                return RedirectToAction("Login");
            ViewData["errorMessage"] = result.Message;
            return View("ChangePassword");
        }
    }
}