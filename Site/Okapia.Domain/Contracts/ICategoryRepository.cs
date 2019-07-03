using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Category;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Category;

namespace Okapia.Domain.Contracts
{
    public interface ICategoryRepository : IRepository<int, Category>
    {
        Category GetCategory(int id);
        EditCategory GetCategoryDetails(int id);
        List<CategoryViewModel> GetCategories();
        List<CategoryViewModel> Search(CategorySearchModel searchModel, out int recordCount);
    }
}