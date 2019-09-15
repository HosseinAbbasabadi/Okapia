using Microsoft.AspNetCore.Mvc;
using Okapia.Domain.QueryContracts;

namespace Okapia.ViewComponents
{
    public class MobileCategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryQuery _categoryQuery;

        public MobileCategoriesViewComponent(ICategoryQuery categoryQuery)
        {
            _categoryQuery = categoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryQuery.GetCategoriesForMenu();
            return View("_MobileCategories", categories);
        }
    }
}