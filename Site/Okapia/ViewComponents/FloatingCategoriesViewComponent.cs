using Microsoft.AspNetCore.Mvc;
using Okapia.Domain.QueryContracts;

namespace Okapia.ViewComponents
{
    public class FloatingCategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryQuery _categoryQuery;

        public FloatingCategoriesViewComponent(ICategoryQuery categoryQuery)
        {
            _categoryQuery = categoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryQuery.GetCategoriesForMenu();
            return View("_FloatingCategories", categories);
        }
    }
}