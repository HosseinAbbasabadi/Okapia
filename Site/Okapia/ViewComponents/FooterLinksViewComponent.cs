using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class FooterLinksViewComponent : ViewComponent
    {
        private readonly ILinkApplication _linkApplication;

        public FooterLinksViewComponent(ILinkApplication linkApplication)
        {
            _linkApplication = linkApplication;
        }

        public IViewComponentResult Invoke()
        {
            var links = _linkApplication.GetLinksForSite();
            return View("_FooterLinks", links);
        }
    }
}