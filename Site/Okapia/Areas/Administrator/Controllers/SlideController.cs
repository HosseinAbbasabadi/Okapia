using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Commands.Slide;
using Okapia.Domain.SeachModels;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class SlideController : Controller
    {
        private readonly ISlideApplication _slideApplication;

        public SlideController(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        // GET: Category
        public ActionResult Index(SlideSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 20;
            }

            var slides = _slideApplication.Search(searchModel, out var recordCount);
            var slideIndex = new SlideIndexViewModel {SlideSearchModel = searchModel, SlideViewModels = slides};
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(slideIndex);
        }


        // GET: Category/Create
        public ActionResult Create()
        {
            var createSlide = new CreateSlide();
            return View(createSlide);
        }

        // POST: Category/Create
        [HttpPost]
        public JsonResult Create(CreateSlide command)
        {
            var result = _slideApplication.Create(command);
            return Json(result);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id, [FromQuery(Name = "redirectUrl")] string redirectUrl)
        {
            var slide = _slideApplication.GetSlideDetails(id);
            ViewData["redirectUrl"] = redirectUrl;
            return View(slide);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(int id, EditSlide command)
        {
            command.SlideId = id;
            var result = _slideApplication.Edit(command);
            return Json(result);
        }

        public ActionResult Delete(int id)
        {
            _slideApplication.Delete(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public ActionResult Activate(int id)
        {
            _slideApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }
    }
}