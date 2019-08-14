using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class PageCategoryMenuViewComponent : ViewComponent
    {
        private readonly IPageCategoryApplication _pageCategoryApplication;

        public PageCategoryMenuViewComponent(IPageCategoryApplication pageCategoryApplication)
        {
            _pageCategoryApplication = pageCategoryApplication;
        }

        public IViewComponentResult Invoke()
        {
            var pageCategories = _pageCategoryApplication.GetPageCategoriesForMenu();            
            return View("PageCategoryMenu", pageCategories);
        }
    }
}