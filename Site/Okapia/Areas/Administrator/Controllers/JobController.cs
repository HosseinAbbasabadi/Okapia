using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Commands.Job;
using Okapia.Application.Contracts;
using Okapia.Application.SeachModels;
using Okapia.Application.Utilities;
using Okapia.Application.ViewModels.Job;
using Okapia.Areas.Administrator.Models;
using System.Drawing;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class JobController : Controller
    {
        private readonly IJobApplication _jobApplication;
        private readonly IHostingEnvironment _hostingEnvironment;

        public JobController(IJobApplication jobApplication, IHostingEnvironment hostingEnvironment)
        {
            _jobApplication = jobApplication;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Shop
        public ActionResult Index()
        {
            var jobs = new List<JobViewModel>
            {
                new JobViewModel
                {
                    JobName = "استخر",
                    JobContactTitile = "علیرضا کرمی",
                    JobManagerFirstName = "علی",
                    JobManagerLastName = "کبیری",
                    JobProvience = "البرز",
                    JobCity = "کرج"
                },
                new JobViewModel
                {
                    JobName = "رستوران سنتی",
                    JobContactTitile = "محمد علیمی",
                    JobManagerFirstName = "سپهر",
                    JobManagerLastName = "جاوید",
                    JobProvience = "لرستان",
                    JobCity = "خرم آباد"
                },
                new JobViewModel
                {
                    JobName = "مرکز تخصصی چشم",
                    JobContactTitile = "حسین حضرتی",
                    JobManagerFirstName = "امیر",
                    JobManagerLastName = "نعیمی",
                    JobProvience = "لرستان",
                    JobCity = "بروجرد"
                },
            };
            var jobIndex = new JobIndexViewModel {JobViewModels = jobs};
            return View(jobIndex);
        }

        // GET: Shop/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            var provinces = new List<Provience>
            {
                new Provience(0, "استان مورد نظر را انتخاب کنید"),
                new Provience(1, "البرز"),
                new Provience(2, "قزوین"),
                new Provience(3, "لرستان")
            };
            var createModel = new CreateJob {Proviences = new SelectList(provinces, "Id", "Name")};
            return View(createModel);
        }

        // POST: Shop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateJob command)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));
            try
            {
                if (command.Photo1 == null) return RedirectToAction(nameof(Index));
                var photos = new List<IFormFile>
                {
                    command.Photo1,
                    command.Photo2,
                    command.Photo3,
                    command.Photo4
                };
                //command.Photos.AddRange(photos);
                var originalImageDistPath = Path.Combine(_hostingEnvironment.WebRootPath, "JobPhotos");
                //var thumbImageDistPath = Path.Combine(_hostingEnvironment.WebRootPath, "JobPhotos", "Thumbs");
                var dateTime = new DateTime();
                foreach (var photo in photos)
                {
                    if (photo == null) continue;
                    var uniqueFileName = ToFileName(DateTime.Now) + "_" + photo.FileName;
                    var filePath = Path.Combine(originalImageDistPath, uniqueFileName);
                    var stream = new FileStream(filePath, FileMode.Create);
                    photo.CopyTo(stream);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                return View();
            }
        }
        private static string ToFileName(DateTime date)
        {
            return $"{date.Year:0000}-{date.Month:00}-{date.Day:00}-{date.Hour:00}-{date.Minute:00}-{date.Second:00}";
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

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Search(JobSearchModel searchModel)
        {
            var searchResult = new List<JobViewModel>();
            var jobIndex = new JobIndexViewModel {JobViewModels = searchResult, JobSearchModel = searchModel};
            return View("Index", jobIndex);
        }
    }
}