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

        public IViewComponentResult Invoke(string pn)
        {
            var categories = _categoryQuery.GetCategoriesForMenu();
            ViewData["province"] = pn;
            return View("_Categories", categories);
        }
    }
}