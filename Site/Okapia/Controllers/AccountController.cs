﻿using System;
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
        private readonly ICookieHelper _cookieHelper;

        public AccountController(IAccountApplication accountApplication, IAuthHelper authHelper,
            ICityApplication cityApplication, IDistrictApplication districtApplication,
            INeighborhoodApplication neighborhoodApplication, ICookieHelper cookieHelper)
        {
            _accountApplication = accountApplication;
            _authHelper = authHelper;
            _cookieHelper = cookieHelper;
        }

        public ActionResult Register()
        {
            if (_authHelper.GetCurrnetUserInfo().IsAuthorized) return RedirectToAction("Index", "Home");
            var createUser = new CreateUser();
            ViewData["province"] = _cookieHelper.Get("province");
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
                var loginResult = _accountApplication.Login(new Login
                {
                    Username = createUser.NationalCardNumber,
                    Password = createUser.PhoneNumber
                });
                if (loginResult.Success)
                {
                    if (loginResult.RecordId == 5 || loginResult.RecordId == 4)
                        return RedirectToAction("Index", "Home", new {area = "Administrator"});
                    if (loginResult.RecordId == 3)
                        return RedirectToAction("Index", "Home", new {area = "Club"});
                    if (loginResult.RecordId == 2)
                        return RedirectToAction("Index", "Home", new {area = "Job"});
                    if (loginResult.RecordId == 1)
                        return RedirectToAction("Index", "Home", new {area = "Customer"});
                }
            }

            ViewData["errorMessage"] = result.Message;
            ViewData["province"] = _cookieHelper.Get("province");
            return View(createUser);
        }

        public ActionResult Login([FromQuery(Name = "redirectUrl")] string redirectUrl)
        {
            if (_authHelper.GetCurrnetUserInfo().IsAuthorized) return RedirectToAction("Index", "Home");
            var login = new Login();
            ViewData["redirectUrl"] = redirectUrl;
            ViewData["province"] = _cookieHelper.Get("province");
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
                if (!string.IsNullOrEmpty(login.RedirectUrl))
                {
                    var redirectUrl = new Uri(login.RedirectUrl);
                    return Redirect(redirectUrl.AbsoluteUri);
                }

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
            ViewData["province"] = _cookieHelper.Get("province");
            return View(login);
        }

        public ActionResult Logout()
        {
            _accountApplication.LogoutUser();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AccessDenied()
        {
            ViewData["province"] = _cookieHelper.Get("province");
            return View();
        }


        public ActionResult ChnagePassword(long id)
        {
            var model = new ChangePassword();
            ViewData["accountId"] = id;
            ViewData["province"] = _cookieHelper.Get("province");
            return PartialView("_ChangePassword", model);
        }

        [HttpPost]
        public JsonResult ChangePassword(long id, ChangePassword command)
        {
            command.AccountId = id;
            var result = _accountApplication.ChangePassword(command);
            return Json(result);
        }

        [ActionName("انتخاب شیوه احراز هویت")]
        public ActionResult ChooseFpMethod()
        {
            var chooseFpMethod = new ChooseFpMethod();
            ViewData["province"] = _cookieHelper.Get("province");
            return View("ChooseFpMethod", chooseFpMethod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChooseFpMethod(ChooseFpMethod command)
        {
            var result = new OperationResult();
            if (!string.IsNullOrEmpty(command.Phonenumber))
            {
                command.Type = "sms";
                result = _accountApplication.CreateVerificationCodeByMobile(command.Phonenumber);
            }

            if (!string.IsNullOrEmpty(command.Email))
            {
                command.Type = "email";
                result = _accountApplication.CreateVerificationCodeByEmail(command.Email);
            }

            if (result.Success)
            {
                return RedirectToAction("تایید کد ارسال شده", command);
            }

            ViewData["errorMessage"] = result.Message;
            return View(command);
        }

        [ActionName("تایید کد ارسال شده")]
        public ActionResult VerifyVerificationCode(ChooseFpMethod command)
        {
            ViewData["province"] = _cookieHelper.Get("province");
            return View("VerifyVerificationCode",command);
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
                return RedirectToAction("تغییر کلمه رمز", routeValues: new {id = result.RecordId});
            ViewData["errorMessage"] = result.Message;
            return View("VerifyVerificationCode");
        }

        [HttpGet]
        [ActionName("تغییر کلمه رمز")]
        public ActionResult ChangePasswordPage(long id)
        {
            var model = new ChangePassword();
            ViewData["accountId"] = id;
            ViewData["province"] = _cookieHelper.Get("province");
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