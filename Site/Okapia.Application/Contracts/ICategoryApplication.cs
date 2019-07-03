using System.Collections.Generic;
using Okapia.Domain.Commands.Category;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Category;

namespace Okapia.Application.Contracts
{
    public interface ICategoryApplication
    {
        void Create(CreateCategory command);
        void Update(EditCategory command);
        EditCategory GetCategoryDetails(int id);
        IEnumerable<CategoryViewModel> GetCategories();
        IEnumerable<CategoryViewModel> GetCategoriesForList(CategorySearchModel searchModel, out int recordCount);
    }
}