using Microsoft.AspNetCore.Mvc;
using Okapia.Domain.QueryContracts;

namespace Okapia.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryQuery _categoryQuery;

        public CategoriesViewComponent(ICategoryQuery categoryQuery)
        {
            _categoryQuery = categoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryQuery.GetCategoriesForMenu();
            return View("_Categories", categories);
        }
    }
}