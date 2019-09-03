using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Models;

namespace Okapia.ViewComponents
{
    public class PageCategoryMenuViewComponent : ViewComponent
    {
        private readonly IAuthHelper _authHelper;
        private readonly IPageCategoryApplication _pageCategoryApplication;

        public PageCategoryMenuViewComponent(IPageCategoryApplication pageCategoryApplication, IAuthHelper authHelper)
        {
            _pageCategoryApplication = pageCategoryApplication;
            _authHelper = authHelper;
        }

        public IViewComponentResult Invoke()
        {
            var authentication = _authHelper.GetCurrnetUserInfo();
            var pageCategories = _pageCategoryApplication.GetPageCategoriesForMenu();
            var index = new PageCategoryMenuIndexViewModel()
            {
                AccountViewModel = authentication,
                PageCategoryMenuViewModels = pageCategories
            };
            return View("PageCategoryMenu", index);
        }
    }
}