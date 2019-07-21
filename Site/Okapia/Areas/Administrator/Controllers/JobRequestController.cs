using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.RequestJob;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class JobRequestController : Controller
    {
        private readonly IJobRequestApplication _jobRequestApplication;

        public JobRequestController(IJobRequestApplication jobRequestApplication)
        {
            _jobRequestApplication = jobRequestApplication;
        }

        public ActionResult Index(JobRequestSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 40;
            }

            var jobRequests = _jobRequestApplication.Search(searchModel, out int recordCount);
            //var employeeSearchModel = ProvideCategorySearchModel(searchModel, categories);
            var jobRequestIndex = ProviceEmployeeIndex(searchModel, jobRequests);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(jobRequestIndex);
        }

        private static JobRequestIndexViewModel ProviceEmployeeIndex(JobRequestSearchModel categorySearchModel,
            List<JobRequestViewModel> categories)
        {
            categorySearchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            return new JobRequestIndexViewModel
            {
                JobRequestSearchModel = categorySearchModel,
                JobRequestViewModels = categories
            };
        }

        // GET: RequestJob/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RequestJob/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequestJob/Create
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

        // GET: RequestJob/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RequestJob/Edit/5
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

        // GET: RequestJob/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RequestJob/Delete/5
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