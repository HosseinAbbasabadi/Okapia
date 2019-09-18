using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class FooterBoxesViewComponent : ViewComponent
    {
        private readonly IBoxApplication _boxApplication;
        public FooterBoxesViewComponent(IBoxApplication boxApplication)
        {
            _boxApplication = boxApplication;
        }

        public IViewComponentResult Invoke()
        {
            var fotterBoxes = _boxApplication.GetBoxesForLandingPage()();
            return View("_FooterBoxes", fotterBoxes);
        }
    }
}