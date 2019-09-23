using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class FooterLinksViewComponent : ViewComponent
    {
        private readonly ILinkGroupApplication _linkGroupApplication;

        public FooterLinksViewComponent(ILinkGroupApplication linkGroupApplication)
        {
            _linkGroupApplication = linkGroupApplication;
        }

        public IViewComponentResult Invoke()
        {
            var linkGroups = _linkGroupApplication.GetFooterLinkGroupsWithLinks();
            return View("_FooterLinks", linkGroups);
        }
    }
}