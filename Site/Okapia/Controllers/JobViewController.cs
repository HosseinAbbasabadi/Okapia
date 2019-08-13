using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Areas.Administrator.Controllers;
using Okapia.Domain.SeachModels;
using Okapia.Models;

namespace Okapia.Controllers
{
    public class JobViewController : Controller
    {
        private readonly IJobApplication _jobApplication;

        public JobViewController(IJobApplication jobApplication, ICityApplication cityApplication)
        {
            _jobApplication = jobApplication;
        }

        public ActionResult Index(JobViewSearchModel searchModel)
        {
            var jobs = _jobApplication.GetJobsForCategoryView(searchModel);
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            var jobIndex = new JobViewIndexViewModel
            {
                JobViewSearchModel = searchModel,
                JobItemViewModels = jobs
            };

            return View(jobIndex);
        }

        // GET: Job/Details/5
        public ActionResult Details(int id)
        {
            var job = _jobApplication.GetJobViewDetails(id);
            return View(job);
        }

        // GET: Job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
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

        // GET: Job/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Job/Edit/5
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

        // GET: Job/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Job/Delete/5
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