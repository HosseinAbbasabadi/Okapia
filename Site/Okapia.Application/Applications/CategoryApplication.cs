using System;
using System.Collections.Generic;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
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
        private readonly IAuthHelper _authHelper;

        public CategoryApplication(ICategoryRepository categoryRepository, IAuthHelper authHelper)
        {
            _categoryRepository = categoryRepository;
            _authHelper = authHelper;
        }

        public OperationResult Create(CreateCategory command)
        {
            var result = new OperationResult("Categories", "Create");
            try
            {
                if (_categoryRepository.Exists(x => x.CategoryName == command.CategoryName))
                {
                    result.Message = ApplicationMessages.DuplicatedCategoryName;
                    return result;
                }

                var category = new Category
                {
                    CategoryName = command.CategoryName,
                    CategoryMetaDesccription = command.CategoryMetaDesccription,
                    CategorySlug = command.CategorySlug,
                    CategoryMetaTag = command.CategoryMetaTag,
                    CategoryPageTittle = command.CategoryPageTittle,
                    CategoryParentId = command.CategoryParentId,
                    CategorySeohead = command.CategorySeohead,
                    CategorySmallDescription = command.CategorySmallDescription,
                    CategoryThumbPicUrl = command.NameImage,
                    CategoryPicTitle = command.TitleImage,
                    CategoryPicAlt = command.AltImage,
                    CategoryPicDescription = command.DescImage,
                    RegisteringEmployeeId = _authHelper.GetCurrnetUserInfo().UserId,
                    IsDeleted = false
                };
                _categoryRepository.Create(category);
                _categoryRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public OperationResult Update(EditCategory command)
        {
            var result = new OperationResult("Categories", "Update");
            try
            {
                var checkingCategory = _categoryRepository.GetCategory(command.CategoryId);
                if (checkingCategory == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var category = new Category
                {
                    CategoryId = command.CategoryId,
                    CategoryName = command.CategoryName,
                    CategoryMetaDesccription = command.CategoryMetaDesccription,
                    CategorySlug = command.CategorySlug,
                    CategoryMetaTag = command.CategoryMetaTag,
                    CategoryPageTittle = command.CategoryPageTittle,
                    CategoryParentId = command.CategoryParentId,
                    CategorySeohead = command.CategorySeohead,
                    CategorySmallDescription = command.CategorySmallDescription,
                    CategoryThumbPicUrl = command.NameImage,
                    CategoryPicTitle = command.TitleImage,
                    CategoryPicAlt = command.AltImage,
                    CategoryPicDescription = command.DescImage,
                    RegisteringEmployeeId = _authHelper.GetCurrnetUserInfo().UserId,
                    IsDeleted = command.IsDeleted
                };
                _categoryRepository.Update(category);
                _categoryRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
            }

            return result;
        }

        public void Delete(int id)
        {
            try
            {
                var category = _categoryRepository.GetCategory(id);
                category.IsDeleted = true;
                _categoryRepository.Update(category);
                _categoryRepository.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void Activate(int id)
        {
            try
            {
                var category = _categoryRepository.GetCategory(id);
                category.IsDeleted = false;
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

        public IEnumerable<CategoryViewModel> Search(CategorySearchModel searchModel, out int recordCount)
        {
            return _categoryRepository.Search(searchModel, out recordCount);
        }

        public OperationResult CheckSlugDuplication(string slug)
        {
            var result = new OperationResult("Categories", "CheckJobSlugDuplication");
            try
            {
                var slugified = Slugify.GenerateSlug(slug);
                if (_categoryRepository.Exists(x => x.CategorySlug == slugified))
                {
                    result.Message = ApplicationMessages.DuplicatedSlug;
                    return result;
                }

                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }
    }
}