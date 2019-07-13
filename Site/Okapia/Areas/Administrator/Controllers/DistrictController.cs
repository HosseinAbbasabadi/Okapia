using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.District;
using Okapia.Domain.SeachModels;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class DistrictController : Controller
    {
        private readonly IDistrictApplication _districtApplication;

        public DistrictController(IDistrictApplication districtApplication)
        {
            _districtApplication = districtApplication;
        }

        // GET: City
        public ActionResult Index(DistrictSearchModel searchModel)
        {
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var districts = _districtApplication.Search(searchModel, out var recordCount);
            var districtIndex =
                new DistrictIndexViewModel {DistrictSearchModel = searchModel, DistrictIndexViewModels = districts};
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(districtIndex);
        }

        public ActionResult ListContent(DistrictSearchModel searchModel)
        {
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var districts = _districtApplication.Search(searchModel, out var recordCount);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return PartialView("_ListDistricts", districts);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            var createDistrict = new CreateDistrict
            {
                Provinces = new SelectList(Provinces.ToList(), "Id", "Name"),
            };
            return PartialView("_Create", createDistrict);
        }

        // POST: City/Create
        [HttpPost]
        public JsonResult Create(CreateDistrict command)
        {
            var result = _districtApplication.Create(command);
            return Json(result);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            var district = _districtApplication.GetDistrictDitails(id);
            district.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            return PartialView("_Edit", district);
        }

        // POST: City/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditDistrict command)
        {
            command.Id = id;
            var result = _districtApplication.Update(command);
            return Json(result);
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
                _districtApplication.Delete(id);
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
                _districtApplication.Activate(id);
                var referer = Request.Headers["Referer"].ToString();
                return Redirect(referer);
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public JsonResult GetDistrictsByCity(int id)
        {
            var cities = _districtApplication.GetDistrictsBy(id);
            return new JsonResult(cities);
        }
    }
}