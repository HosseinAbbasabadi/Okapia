using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Category;

namespace Okapia.Application.Contracts
{
    public interface ICategoryApplication
    {
        IEnumerable<CategoryViewModel> GetCategories();
        IEnumerable<CategoryViewModel> GetCategoriesForList(CategorySearchModel searchModel, out int recordCount);
    }
}