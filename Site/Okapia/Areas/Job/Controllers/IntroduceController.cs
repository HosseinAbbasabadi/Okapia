using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Customer.Models;
using Okapia.Domain.Commands.User;
using Okapia.Domain.SeachModels;

namespace Okapia.Areas.Job.Controllers
{
    [Area("Job")]
    [Authorize(Roles = "2")]
    public class IntroduceController : Controller
    {
        private readonly IUserApplication _userApplication;

        public IntroduceController(IUserApplication userApplication, IAuthHelper authHelper)
        {
            _userApplication = userApplication;
        }

        // GET: Introduce
        public ActionResult Index(IntroducedSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 20;
            }

            var users = _userApplication.SearchIntroduced(searchModel, out var recordCount);
            var userIndexViewModel = new IntroducedIndexViewModel
            {
                IntroducedSearchModel = searchModel,
                IntroducedViewModels = users
            };
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(userIndexViewModel);
        }

        // GET: Introduce/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Introduce/Create
        public ActionResult Create()
        {
            var createUser = new CreateUser();
            return View(createUser);
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