using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Okapia.Application.Commands.Job;
using Okapia.Application.Contracts;
using Okapia.Application.SeachModels;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class JobController : Controller
    {
        private readonly IJobApplication _jobApplication;

        public JobController(IJobApplication jobApplication)
        {
            _jobApplication = jobApplication;
        }

        // GET: Shop
        public ActionResult Index()
        {
            var jobs = new List<CreateJob>
            {
                new CreateJob
                {
                    JobName = "استخر",
                    JobContactTitile = "علیرضا کرمی",
                    JobManagerFirstName = "علی",
                    JobManagerLastName = "کبیری",
                    //JobProvienceId = "البرز",
                    //JobCityId = "کرج"
                },new CreateJob
                {
                    JobName = "رستوران سنتی",
                    JobContactTitile = "محمد علیمی",
                    JobManagerFirstName = "سپهر",
                    JobManagerLastName = "جاوید",
                    //JobProvienceId = "لرستان",
                    //JobCityId = "خرم آباد"
                },new CreateJob
                {
                    JobName = "مرکز تخصصی چشم",
                    JobContactTitile = "حسین حضرتی",
                    JobManagerFirstName = "امیر",
                    JobManagerLastName = "نعیمی",
                    //JobProvienceId = "لرستان",
                    //JobCityId = "بروجرد"
                },
            };
            return View(jobs);
        }

        // GET: Shop/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateJob command)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shop/Edit/5
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

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shop/Delete/5
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(JobSearchModel searchModel)
        {
            var data = new List<CreateJob>();
            return View("Index", data);
        }
    }
}