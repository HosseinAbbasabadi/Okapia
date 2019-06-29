using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Commands.Job;
using Okapia.Application.Contracts;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class JobController : Controller
    {
        private readonly IJobApplication _jobApplication;
        private readonly ICityApplication _cityApplication;
        private readonly IDistrictApplication _districtApplication;
        private readonly INeighborhoodApplication _neighborhoodApplication;


        public JobController(IJobApplication jobApplication, ICityApplication cityApplication,
            IDistrictApplication districtApplication, INeighborhoodApplication neighborhoodApplication)
        {
            _jobApplication = jobApplication;
            _cityApplication = cityApplication;
            _districtApplication = districtApplication;
            _neighborhoodApplication = neighborhoodApplication;
        }

        private void PreparePager(BaseSerachModel searchModel, int rc)
        {
            if (rc % searchModel.PageSize == 0)
            {
                searchModel.PageCount = rc / searchModel.PageSize;
            }
            else
            {
                searchModel.PageCount = (rc / searchModel.PageSize) + 1;
            }

            ViewData["searchModel"] = searchModel;
        }

        // GET: Shop
        public ActionResult Index(JobSearchModel searchMd)
        {
            var jobSearchModel = ProvideJobSearchModel(searchMd);

            var jobs = _jobApplication.GetJobsForList(jobSearchModel, out var recordCount);
            var jobIndex = ProvideJobIndex(jobs, jobSearchModel);
            PreparePager(jobSearchModel, recordCount);
            return View(jobIndex);
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Search(JobSearchModel searchModel)
        {
            ProvideJobSearchModel(searchModel);
            var jobs = _jobApplication.GetJobsForList(searchModel, out var recordCount);
            var jobIndex = ProvideJobIndex(jobs, searchModel);
            PreparePager(searchModel, recordCount);
            return View("Index", jobIndex);
        }
        private static JobSearchModel ProvideJobSearchModel(JobSearchModel searchModel)
        {
            searchModel.Proviences = new SelectList(Proviences(), "Id", "Name");
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 1;
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
            var createModel = new CreateJob {Proviences = new SelectList(Proviences(), "Id", "Name")};
            return View(createModel);
        }

        private static List<Provience> Proviences()
        {
            return new List<Provience>
            {
                new Provience(0, "استان مورد نظر را انتخاب کنید"),
                new Provience(31, "البرز"),
                new Provience(27, "قزوین"),
                new Provience(16, "لرستان")
            };
        }

        // POST: Shop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateJob command)
        {
            //TODO: return appropiated message by viewdata
            if (!ModelState.IsValid) return View(command);
            try
            {
                if (command.Photo1 == null) return View(command);
                //TODO: Make it 6 photos
                var photos = new List<IFormFile>
                {
                    command.Photo1,
                    command.Photo2,
                    command.Photo3,
                    command.Photo4,
                    command.Photo5,
                    command.Photo6
                };
                command.Photos = photos;

                _jobApplication.Create(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
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

        [HttpGet]
        public JsonResult GetCitiesByProvince(int id)
        {
            var cities = _cityApplication.GetCitiesBy(id);
            return new JsonResult(cities);
        }

        [HttpGet]
        public JsonResult GetDistrictsByCity(int id)
        {
            var cities = _districtApplication.GetDistrictsBy(id);
            return new JsonResult(cities);
        }

        [HttpGet]
        public JsonResult GetNeighborhoodsByDistrict(int id)
        {
            var cities = _neighborhoodApplication.GetNeighborhoodsBy(id);
            return new JsonResult(cities);
        }

        private static IEnumerable<JobViewModel> CreateJobs()
        {
            return new List<JobViewModel>
            {
                new JobViewModel
                {
                    JobName = "استخر",
                    JobContactTitile = "علیرضا کرمی",
                    JobManagerFirstName = "علی",
                    JobManagerLastName = "کبیری",
                    JobProvience = "البرز",
                    JobCity = "کرج",
                    JobDistrict = "منطقه",
                    JobNeighborhood = "محله"
                },
                new JobViewModel
                {
                    JobName = "رستوران سنتی",
                    JobContactTitile = "محمد علیمی",
                    JobManagerFirstName = "سپهر",
                    JobManagerLastName = "جاوید",
                    JobProvience = "لرستان",
                    JobCity = "خرم آباد",
                    JobDistrict = "منطقه",
                    JobNeighborhood = "محله"
                },
                new JobViewModel
                {
                    JobName = "مرکز تخصصی چشم",
                    JobContactTitile = "حسین حضرتی",
                    JobManagerFirstName = "امیر",
                    JobManagerLastName = "نعیمی",
                    JobProvience = "لرستان",
                    JobCity = "بروجرد",
                    JobDistrict = "منطقه",
                    JobNeighborhood = "محله"
                },
            };
        }
    }
}