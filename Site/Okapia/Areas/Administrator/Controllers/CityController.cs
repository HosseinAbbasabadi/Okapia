using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.City;
using Okapia.Domain.SeachModels;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
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

            var cities = _cityApplication.Search(searchModel, out var recordCount);
            var cityIndex = new CityIndexViewModel {CitySearchModel = searchModel, CityViewModeles = cities};
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(cityIndex);
        }

        public ActionResult ListContent(CitySearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var cities = _cityApplication.Search(searchModel, out int recordCount);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return PartialView("_ListCity", cities);
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
        //[ValidateAntiForgeryToken]
        public JsonResult Create(CreateCity command)
        {
            var result = _cityApplication.Create(command);
            return Json(result);
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
        public JsonResult Edit(int id, EditCity command)
        {
            command.Id = id;
            var result = _cityApplication.Update(command);
            return Json(result);
        }

        // POST: City/Delete/5
        public ActionResult Delete(int id)
        {
            _cityApplication.Delete(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public ActionResult Activate(int id)
        {
            _cityApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        [HttpGet]
        public JsonResult GetCitiesByProvince(int id)
        {
            var cities = _cityApplication.GetCitiesBy(id);
            return new JsonResult(cities);
        }
    }
}