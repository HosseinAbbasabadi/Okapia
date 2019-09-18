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

        public IViewComponentResult Invoke()
        {
            var boxes = _boxApplication.GetBoxesForLandingPage();
            return View("_Boxes", boxes);
        }
    }
}