using System.Collections.Generic;
using Okapia.Application.Contracts;
using Okapia.Domain.Contracts;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Category;

namespace Okapia.Application.Applications
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApplication(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        public IEnumerable<CategoryViewModel> GetCategoriesForList(CategorySearchModel searchModel, out int recordCount)
        {
            return _categoryRepository.Search(searchModel, out recordCount);
        }
    }
}
