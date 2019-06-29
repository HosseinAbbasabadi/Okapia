using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Category;

namespace Okapia.Domain.Contracts
{
    public interface ICategoryRepository : IRepository<int, Category>
    {
        List<CategoryViewModel> GetCategories();
        List<CategoryViewModel> Search(CategorySearchModel searchModel, out int recordCount);
    }
}