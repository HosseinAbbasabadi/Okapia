using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.ViewModels.Category;
using System.Collections.Generic;

namespace Okapia.Domain.QueryContracts
{
    public interface ICategoryQuery : IRepository<int, Category>
    {
        List<CategoryViewModel> GetCategoriesForSearch();
        List<CategoryMenuViewModel> GetCategoriesForMenu();
    }
}