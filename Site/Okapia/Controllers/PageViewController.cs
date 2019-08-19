using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.Controllers
{
    public class PageViewController : Controller
    {
        private readonly IPageApplication _pageApplication;
        private readonly IPageCategoryApplication _pageCategoryApplication;

        public PageViewController(IPageApplication pageApplication, IPageCategoryApplication pageCategoryApplication)
        {
            _pageApplication = pageApplication;
            _pageCategoryApplication = pageCategoryApplication;
        }

        public ActionResult Index(int id)
        {
            var pageCategory = _pageCategoryApplication.GetPageCategoryForBlog(id);
            return View(pageCategory);
        }

        public ActionResult Details(int id)
        {
            var pageDetails = _pageApplication.GetPageDetailsForView(id);
            return View(pageDetails);
        }
    }
}