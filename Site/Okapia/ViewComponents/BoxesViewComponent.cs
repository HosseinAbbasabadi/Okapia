using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class BoxesViewComponent : ViewComponent
    {
        private readonly IBoxApplication _boxApplication;
        private readonly ICookieHelper _cookieHelper;
        public BoxesViewComponent(IBoxApplication boxApplication, ICookieHelper cookieHelper)
        {
            _boxApplication = boxApplication;
            _cookieHelper = cookieHelper;
        }

        public IViewComponentResult Invoke(string pn)
        {
            //var pn = _cookieHelper.Get("province");
            var boxes = _boxApplication.GetBoxesForLandingPage(pn);
            return View("_Boxes", boxes);
        }
    }
}