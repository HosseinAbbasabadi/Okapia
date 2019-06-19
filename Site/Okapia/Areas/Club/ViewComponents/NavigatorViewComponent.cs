using Microsoft.AspNetCore.Mvc;
using Okapia.Helpers;

namespace Okapia.Areas.Club.ViewComponents
{
    public class NavigatorViewComponent : ViewComponent
    {
        private readonly IAuthHelper _authHelper;

        public NavigatorViewComponent(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public IViewComponentResult Invoke()
        {
            ViewData["Auth"] = _authHelper.GetAuthenticationInfo();
            return View("Default");
        }
    }
}
