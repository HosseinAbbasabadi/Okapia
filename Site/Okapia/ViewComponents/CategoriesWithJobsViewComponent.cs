using Microsoft.AspNetCore.Mvc;
using Okapia.Domain.QueryContracts;

namespace Okapia.ViewComponents
{
    public class CategoriesWithJobsViewComponent : ViewComponent
    {
        private readonly ICategoryQuery _categoryQuery;

        public CategoriesWithJobsViewComponent(ICategoryQuery categoryQuery)
        {
            _categoryQuery = categoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryQuery.GetCategoriesForMenu();
            return View("_CategoriesWithJobs", categories);
        }
    }
}