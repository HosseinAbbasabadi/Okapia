using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.SeachModels;
using Okapia.Helpers;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    //[ServiceFilter(typeof(AuthorizeFilter))]
    public class UserController : Controller
    {
        private readonly IUserApplication _userApplication;
        private readonly IAccountApplication _accountApplication;

        public UserController(IUserApplication userApplication, IAccountApplication accountApplication)
        {
            _userApplication = userApplication;
            _accountApplication = accountApplication;
        }

        public ActionResult Index(UserSearchModel searchModel)
        {
            if (searchModel.PageSize == 0)
            {
                searchModel.PageSize = 20;
            }

            var users = _userApplication.Search(searchModel, out var recordCount);
            searchModel.Provinces = new SelectList(Provinces.ToList(), "Id", "Name");
            var userIndexViewModel = new UserIndexViewModel()
            {
                UserSearchModel = searchModel,
                UserViewModels = users
            };
            Pager.PreparePager(searchModel, recordCount);
            ViewData["searchModel"] = searchModel;
            return View(userIndexViewModel);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = _userApplication.GetUserDetails(id, Constants.Roles.User.Id);
            return PartialView("_UserDetails", user);
        }

        public ActionResult Delete(int id)
        {
            _accountApplication.Delete(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public ActionResult Activate(long id)
        {
            _accountApplication.Activate(id);
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }
    }
}