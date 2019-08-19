using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class LatestPagesBlogSideViewComponent : ViewComponent
    {
        private readonly IPageApplication _pageApplication;

        public LatestPagesBlogSideViewComponent(IPageApplication pageApplication)
        {
            _pageApplication = pageApplication;
        }

        public IViewComponentResult Invoke()
        {
            var pages = _pageApplication.GetPagesForLatestArticles();
            return View("_LatestPagesBlogSide", pages);
        }
    }
}