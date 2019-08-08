using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IAuthHelper _authHelper;
        private readonly ICategoryApplication _categoryApplication;

        public MenuViewComponent(IAuthHelper authHelper, ICategoryApplication categoryApplication)
        {
            _authHelper = authHelper;
            _categoryApplication = categoryApplication;
        }

        public IViewComponentResult Invoke()
        {
            var authentication = _authHelper.GetCurrnetUserInfo();
            var categories = _categoryApplication.GetCategoriesForMenu();
            return View("Default", authentication);
        }
    }
}
