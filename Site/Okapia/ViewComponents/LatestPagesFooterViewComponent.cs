using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class LatestPagesFooterViewComponent : ViewComponent
    {
        private readonly IPageApplication _pageApplication;

        public LatestPagesFooterViewComponent(IPageApplication pageApplication)
        {
            _pageApplication = pageApplication;
        }

        public IViewComponentResult Invoke()
        {
            var pages = _pageApplication.GetPagesForLatestArticles();
            return View("_LatestPagesFooter", pages);
        }
    }
}