using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class PageCategoryBlogSideViewComponent : ViewComponent
    {
        private readonly IPageCategoryApplication _pageCategoryApplication;

        public PageCategoryBlogSideViewComponent(IPageCategoryApplication pageCategoryApplication)
        {
            _pageCategoryApplication = pageCategoryApplication;
        }

        public IViewComponentResult Invoke()
        {
            var pageCategories = _pageCategoryApplication.GetPageCategoriesForMenu();            
            return View("_PageCategoryBlogSide", pageCategories);
        }
    }
}