using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Models;

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
            var menuViewModel = new MenuViewModel
            {
                AccountViewModel = authentication,
                CategoryMenuViewModels = categories
            };
            return View("Default", menuViewModel);
        }
    }
}
