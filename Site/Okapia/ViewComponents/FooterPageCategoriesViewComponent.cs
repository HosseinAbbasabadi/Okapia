using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class FooterPageCategoriesViewComponent : ViewComponent
    {
        private readonly IPageCategoryApplication _pageCategoryApplication;

        public FooterPageCategoriesViewComponent(IPageCategoryApplication pageCategoryApplication)
        {
            _pageCategoryApplication = pageCategoryApplication;
        }

        public IViewComponentResult Invoke()
        {
            var pages = _pageCategoryApplication.GetPageCategoriesForFooter();
            return View("_FooterPageCategories", pages);
        }
    }
}