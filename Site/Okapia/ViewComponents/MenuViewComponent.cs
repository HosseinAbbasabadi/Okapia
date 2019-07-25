using System;
using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IAuthHelper _authHelper;

        public MenuViewComponent(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public IViewComponentResult Invoke()
        {
            var authentication = _authHelper.GetCurrnetUserInfo();
            return View("Default", authentication);
        }
    }
}
