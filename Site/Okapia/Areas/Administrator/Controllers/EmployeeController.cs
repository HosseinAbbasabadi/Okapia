using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Employee;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Employee;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeApplication _employeeApplication;

        public EmployeeController(IEmployeeApplication employeeApplication)
        {
            _employeeApplication = employeeApplication;
        }

        // GET: Category
        public ActionResult Index(EmployeeSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 20;
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
            ViewData["searchModel"] = searchModel;
            return PartialView("_ListEmployees", employees);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var createModel = new CreateEmployee();
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
            return PartialView("_Edit",employee);
        }

        // POST: Category/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(int id, EditEmployee command)
        {
            command.EmployeeId = id;
            var result = _employeeApplication.Update(command);
            return Json(result);
        }

        //// GET: Category/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        public ActionResult Delete(int id)
        {
            _employeeApplication.Delete(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public ActionResult Activate(int id)
        {
            _employeeApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }
    }
}