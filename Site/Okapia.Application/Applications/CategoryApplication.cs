using System;
using System.Collections.Generic;
using Okapia.Application.Contracts;
using Okapia.Domain.Commands.Category;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
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

        public void Create(CreateCategory command)
        {
            var category = new Category
            {
                CategoryName = command.CategoryName,
                CategoryMetaDesccription = command.CategoryMetaDesccription,
                CategoryMetaTag = command.CategoryMetaTag,
                CategoryPageTittle = command.CategoryPageTittle,
                CategoryParentId = command.CategoryParentId,
                CategorySeohead = command.CategorySeohead,
                CategorySmallDescription = command.CategorySmallDescription,
                CategoryThumbPicUrl = command.NameImage,
                RegisteringEmployeeId = 1
            };
            _categoryRepository.Create(category);
            _categoryRepository.SaveChanges();
        }

        public void Update(EditCategory command)
        {
            try
            {
                var checkingCategory = _categoryRepository.GetCategory(command.CategoryId);
                if (checkingCategory == null) return;
                var category = new Category
                {
                    CategoryId = command.CategoryId,
                    CategoryMetaDesccription = command.CategoryMetaDesccription,
                    CategoryMetaTag = command.CategoryMetaTag,
                    CategoryName = command.CategoryName,
                    CategoryPageTittle = command.CategoryPageTittle,
                    CategoryParentId = command.CategoryParentId,
                    CategorySeohead = command.CategorySeohead,
                    CategorySmallDescription = command.CategorySmallDescription,
                    CategoryThumbPicUrl = command.NameImage,
                    RegisteringEmployeeId = 1
                };
                _categoryRepository.Update(category);
                _categoryRepository.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public EditCategory GetCategoryDetails(int id)
        {
            return _categoryRepository.GetCategoryDetails(id);
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