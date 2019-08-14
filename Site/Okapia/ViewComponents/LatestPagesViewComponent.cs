using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class LatestPagesViewComponent : ViewComponent
    {
        private readonly IPageApplication _pageApplication;

        public LatestPagesViewComponent(IPageApplication pageApplication)
        {
            _pageApplication = pageApplication;
        }

        public IViewComponentResult Invoke()
        {
            var pages = _pageApplication.GetPagesForLatestArticles();
            return View("_LatestPages", pages);
        }
    }
}