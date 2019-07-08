using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Helpers;

namespace Okapia.Areas.Job.ViewComponents
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
            ViewData["Auth"] = _authHelper.GetUserInfo();
            return View("Default");
        }
    }
}
