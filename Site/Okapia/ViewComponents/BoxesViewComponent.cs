using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class BoxesViewComponent : ViewComponent
    {
        private readonly IBoxApplication _boxApplication;
        public BoxesViewComponent(IBoxApplication boxApplication)
        {
            _boxApplication = boxApplication;
        }

        public IViewComponentResult Invoke(string pn)
        {
            var boxes = _boxApplication.GetBoxesForLandingPage(pn);
            return View("_Boxes", boxes);
        }
    }
}