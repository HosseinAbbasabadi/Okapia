using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

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
            ViewData["Auth"] = _authHelper.GetCurrnetUserInfo();
            return View("Default");
        }
    }
}
