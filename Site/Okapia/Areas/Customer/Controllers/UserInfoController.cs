using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.Areas.Customer.Controllers
{
    [Area("Customer")]
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

        // GET: UserInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserInfo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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