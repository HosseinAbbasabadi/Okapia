using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Category;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Category;

namespace Okapia.Application.Contracts
{
    public interface ICategoryApplication
    {
        OperationResult Create(CreateCategory command);
        OperationResult Update(EditCategory command);
        void Delete(int id);
        void Activate(int id);
        EditCategory GetCategoryDetails(int id);
        IEnumerable<CategoryViewModel> GetCategories();
        IEnumerable<CategoryViewModel> Search(CategorySearchModel searchModel, out int recordCount);
        OperationResult CheckSlugDuplication(string slug);
    }
}