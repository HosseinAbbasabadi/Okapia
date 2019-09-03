using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.SeachModels;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class ContactController : Controller
    {
        private readonly IContactApplication _contactApplication;

        public ContactController(IContactApplication contactApplication)
        {
            _contactApplication = contactApplication;
        }

        public ActionResult Index(ContactSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 20;
            }

            var contacts = _contactApplication.Search(searchModel, out var recordCount);
            var index = new ContactIndexViewModel
            {
                ContactSearchModel = searchModel,
                ContactViewModels = contacts
            };
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(index);
        }

        public ActionResult ListContent(ContactSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 20;
            }

            var contacts = _contactApplication.Search(searchModel, out var recordCount);
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return PartialView("_ListContacts", contacts);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            var contact = _contactApplication.GetDetails(id);
            return PartialView("_ContactDetails", contact);
        }

        public JsonResult Check(int id)
        {
            var result = _contactApplication.Check(id);
            return Json(result);
        }
    }
}