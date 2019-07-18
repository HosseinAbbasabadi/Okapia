using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands;
using Okapia.Domain.Commands.Employee;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Employee;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeApplication _employeeApplication;
        private readonly IControllerApplication _controllerApplication;
        private readonly IAccountApplication _accountApplication;

        public EmployeeController(IEmployeeApplication employeeApplication,
            IControllerApplication controllerApplication, IAccountApplication accountApplication)
        {
            _employeeApplication = employeeApplication;
            _controllerApplication = controllerApplication;
            _accountApplication = accountApplication;
        }

        // GET: Category
        public ActionResult Index(EmployeeSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 4;
            }

            var employees = _employeeApplication.Search(searchModel, out int recordCount).ToList();
            //var employeeSearchModel = ProvideCategorySearchModel(searchModel, categories);
            var employeeIndex = ProviceEmployeeIndex(searchModel, employees);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(employeeIndex);
        }

        private static EmployeeIndexViewModel ProviceEmployeeIndex(EmployeeSearchModel categorySearchModel,
            IEnumerable<EmployeeViewModel> categories)
        {
            return new EmployeeIndexViewModel
            {
                EmployeeSearchModel = categorySearchModel,
                EmployeeViewModels = categories
            };
        }

        public ActionResult ListContent(EmployeeSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 20;
            }

            var employees = _employeeApplication.Search(searchModel, out int recordCount).ToList();
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return PartialView("_ListEmployees", employees);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var createModel = new CreateEmployee
            {
                SelectedControllers = new List<string> {"1"},
                AvailableControllers = _controllerApplication.GetControllers()
            };
            return PartialView("_Create", createModel);
        }

        // POST: Category/Create
        [HttpPost]
        public JsonResult Create(CreateEmployee command)
        {
            var result = _employeeApplication.Create(command);
            return Json(result);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id, [FromQuery(Name = "redirectUrl")] string redirectUrl)
        {
            var employee = _employeeApplication.GetEmployeeDetails(id);
            ViewData["redirectUrl"] = redirectUrl;
            return PartialView("_Edit", employee);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(int id, EditEmployee command)
        {
            command.EmployeeId = id;
            var result = _employeeApplication.Update(command);
            return Json(result);
        }

        public ActionResult Delete(long id)
        {
            _accountApplication.Delete(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public ActionResult Activate(long id)
        {
            _accountApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }
    }
}