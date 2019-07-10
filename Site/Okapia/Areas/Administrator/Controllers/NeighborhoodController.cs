using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Neighborhood;
using Okapia.Domain.SeachModels;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class NeighborhoodController : Controller
    {
        private readonly INeighborhoodApplication _neighborhoodApplication;

        public NeighborhoodController(INeighborhoodApplication neighborhoodApplication)
        {
            _neighborhoodApplication = neighborhoodApplication;
        }

        // GET: City
        public ActionResult Index(NeighborhoodSearchModel searchModel)
        {
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var neighborhoods = _neighborhoodApplication.GetNeighborhoodsForList(searchModel, out var recordCount);
            var neighborhoodINdex =
                new NeighborhoodIndexViewModel
                {
                    NeighborhoodSearchModel = searchModel,
                    NeighborhoodViewModels = neighborhoods
                };
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(neighborhoodINdex);
        }

        // GET: City/Details/5
        public ActionResult Details(NeighborhoodSearchModel searchModel)
        {
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 80;
            }

            var neighborhoods = _neighborhoodApplication.GetNeighborhoodsForList(searchModel, out var recordCount);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return PartialView("_ListNeighborhoods", neighborhoods);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            var createNeighborhood = new CreateNeighborhood
            {
                Provinces = new SelectList(Provinces.ToList(), "Id", "Name"),
            };
            return PartialView("_Create", createNeighborhood);
        }

        // POST: City/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateNeighborhood command)
        {
            var result = _neighborhoodApplication.Create(command);
            return Json(result);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            var neighborhood = _neighborhoodApplication.GetNeighborhoodDetails(id);
            neighborhood.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            return PartialView("_Edit", neighborhood);
        }

        // POST: City/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditNeighborhood command)
        {
            command.Id = id;
            var result = _neighborhoodApplication.Update(command);
            return Json(result);
        }

        // POST: City/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _neighborhoodApplication.Delete(id);
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
                _neighborhoodApplication.Activate(id);
                var referer = Request.Headers["Referer"].ToString();
                return Redirect(referer);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public JsonResult GetNeighborhoodsByDistrict(int id)
        {
            var cities = _neighborhoodApplication.GetNeighborhoodsBy(id);
            return new JsonResult(cities);
        }
    }
}