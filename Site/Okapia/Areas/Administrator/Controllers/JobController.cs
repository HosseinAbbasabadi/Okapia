using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Job;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;
using Okapia.Domain.ViewModels.JobPicture;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class JobController : Controller
    {
        private readonly IJobApplication _jobApplication;
        private readonly ICategoryApplication _categoryApplication;

        public JobController(IJobApplication jobApplication, ICategoryApplication categoryApplication)
        {
            _jobApplication = jobApplication;
            _categoryApplication = categoryApplication;
        }

        // GET: Shop
        public ActionResult Index(JobSearchModel searchModel)
        {
            var jobIndex = RenderPage(searchModel);
            return View(jobIndex);
        }

        private JobIndexViewModel RenderPage(JobSearchModel searchModel)
        {
            var jobSearchModel = ProvideJobSearchModel(searchModel);
            var jobs = _jobApplication.GetJobsForList(jobSearchModel, out var recordCount);
            var jobIndex = ProvideJobIndex(jobs, jobSearchModel);
            Pager.PreparePager(jobSearchModel, recordCount);
            ViewData["searchModel"] = jobSearchModel;
            return jobIndex;
        }

        //[HttpGet]
        ////[ValidateAntiForgeryToken]
        //public ActionResult Search(JobSearchModel searchModel)
        //{
        //    ProvideJobSearchModel(searchModel);
        //    var jobs = _jobApplication.GetJobsForList(searchModel, out var recordCount);
        //    var jobIndex = ProvideJobIndex(jobs, searchModel);
        //    Pager.PreparePager(searchModel, recordCount);
        //    return View("Index", jobIndex);
        //}

        private JobSearchModel ProvideJobSearchModel(JobSearchModel searchModel)
        {
            searchModel.Proviences = new SelectList(Provinces.ToList(), "Id", "Name");
            searchModel.Categories = new SelectList(_categoryApplication.GetCategories(), "CategoryId", "CategoryName");
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 40;
            }

            return searchModel;
        }

        private static JobIndexViewModel ProvideJobIndex(IEnumerable<JobViewModel> jobs, JobSearchModel jobSearchModel)
        {
            var jobIndex = new JobIndexViewModel
            {
                JobViewModels = jobs,
                JobSearchModel = jobSearchModel
            };
            return jobIndex;
        }

        // GET: Shop/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            var createModel = new CreateJob
            {
                Proviences = new SelectList(Provinces.ToList(), "Id", "Name"),
                Categories = new SelectList(_categoryApplication.GetCategories(), "CategoryId", "CategoryName")
            };
            return View(createModel);
        }

        // POST: Shop/Create
        [HttpPost]
        public JsonResult Create(CreateJob command)
        {
            var photos = new List<string>
            {
                command.NamePhoto1,
                command.NamePhoto2,
                command.NamePhoto3,
                command.NamePhoto4,
                command.NamePhoto5,
                command.NamePhoto6
            };
            command.Photos = photos;
            var result = _jobApplication.Create(command);
            return Json(result);
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int id, [FromQuery(Name = "redirectUrl")] string redirectUrl)
        {
            var editJob = _jobApplication.GetJobDetails(id);
            editJob.Proviences = new SelectList(Provinces.ToList(), "Id", "Name");
            editJob.Categories = new SelectList(_categoryApplication.GetCategories(), "CategoryId", "CategoryName");
            ViewData["redirectUrl"] = redirectUrl;
            return View(editJob);
        }

        // POST: Shop/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(int id, EditJob command)
        {
            var photos = new List<JobPictureViewModel>
            {
                new JobPictureViewModel {Id = command.NamePhoto1Id, Name = command.NamePhoto1},
                new JobPictureViewModel {Id = command.NamePhoto2Id, Name = command.NamePhoto2},
                new JobPictureViewModel {Id = command.NamePhoto3Id, Name = command.NamePhoto3},
                new JobPictureViewModel {Id = command.NamePhoto4Id, Name = command.NamePhoto4},
                new JobPictureViewModel {Id = command.NamePhoto5Id, Name = command.NamePhoto5},
                new JobPictureViewModel {Id = command.NamePhoto6Id, Name = command.NamePhoto6},
            };
            //var nullPhotos = photos.Where(x => x == null).ToList();
            //nullPhotos.ForEach(x=> photos.Remove(x));
            command.JobId = id;
            command.Photos = photos;
            var result = _jobApplication.Update(id, command);
            return Json(result);
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
                var redirect301Url = collection["301Redirect"].ToString();
                _jobApplication.Delete(id, redirect301Url);
                var referer = Request.Headers["Referer"].ToString();
                return Redirect(referer);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Activate(int id)
        {
            try
            {
                _jobApplication.Activate(id);
                var referer = Request.Headers["Referer"].ToString();
                return Redirect(referer);
            }
            catch
            {
                return View();
            }
        }

        public JsonResult CheckSlugDuplication(string id)
        {
            var result = _jobApplication.CheckJobSlugDuplication(id);
            return Json(result);
        }
    }
}