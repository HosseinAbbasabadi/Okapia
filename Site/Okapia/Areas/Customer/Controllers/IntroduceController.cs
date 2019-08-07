using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Domain.Commands.User;

namespace Okapia.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "1")]
    public class IntroduceController : Controller
    {
        private readonly IUserApplication _userApplication;
        private readonly IAuthHelper _authHelper;

        public IntroduceController(IUserApplication userApplication, IAuthHelper authHelper)
        {
            _userApplication = userApplication;
            _authHelper = authHelper;
        }

        // GET: Introduce
        public ActionResult Index()
        {
            var createUser = new CreateUser();
            return View(createUser);
        }

        // GET: Introduce/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Introduce/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Introduce/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create(CreateUser command)
        {
            var result = _userApplication.Introduce(command);
            return Json(result);
        }

        // GET: Introduce/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Introduce/Edit/5
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

        // GET: Introduce/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Introduce/Delete/5
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