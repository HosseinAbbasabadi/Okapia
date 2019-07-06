using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.City;
using Okapia.Domain.SeachModels;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CityController : Controller
    {
        private readonly ICityApplication _cityApplication;

        public CityController(ICityApplication cityApplication)
        {
            _cityApplication = cityApplication;
        }

        // GET: City
        public ActionResult Index(CitySearchModel searchModel)
        {
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var cities = _cityApplication.GetCitiesForList(searchModel, out var recordCount);
            var cityIndex = new CityIndexViewModel {CitySearchModel = searchModel, CityViewModeles = cities};
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(cityIndex);
        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: City/Create
        public ActionResult Create()
        {
            var createCity = new CreateCity
            {
                Provinces = new SelectList(Provinces.ToList(), "Id", "Name")
            };
            return PartialView("_Create", createCity);
        }

        // POST: City/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCity command)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _cityApplication.Create(command);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            return Json("ok");
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            var city = _cityApplication.GetCityDetails(id);
            city.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            return PartialView("_Edit", city);
        }

        // POST: City/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditCity command)
        {
            try
            {
                _cityApplication.Update(command);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: City/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: City/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _cityApplication.Delete(id);
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
                _cityApplication.Activate(id);
                var referer = Request.Headers["Referer"].ToString();
                return Redirect(referer);
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
    }
}