using Microsoft.AspNetCore.Mvc;

namespace Okapia.Areas.Administrator.ViewComponents
{
    public class NavigatorViewComponent : ViewComponent
    {

        public NavigatorViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            //ViewData["Auth"] = _authHelper.GetAuthenticationInfo();
            return View("Default");
        }
    }
}
