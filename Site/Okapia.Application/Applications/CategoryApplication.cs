using System;
using System.Collections.Generic;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Category;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Category;

namespace Okapia.Application.Applications
{
    public class CategoryApplication : ICategoryApplication

    {
        private readonly ICategoryQuery _categoryQuery;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthHelper _authHelper;

        public CategoryApplication(ICategoryRepository categoryRepository, IAuthHelper authHelper,
            ICategoryQuery categoryQuery)
        {
            _categoryRepository = categoryRepository;
            _authHelper = authHelper;
            _categoryQuery = categoryQuery;
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
                    CategoryCanonicalAddress = command.CategoryCanonicalAddress,
                    CategoryColor = command.CategoryColor,
                    CategoryIcon = command.CategoryIcon,
                    CategoryIsNew = command.CategoryIsNew,
                    RegisteringEmployeeId = _authHelper.GetCurrnetUserInfo().AuthUserId,
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
                if (!_categoryRepository.Exists(x => x.CategoryId == command.CategoryId))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var category = _categoryRepository.GetCategory(command.CategoryId);

                category.CategoryName = command.CategoryName;
                category.CategoryMetaDesccription = command.CategoryMetaDesccription;
                category.CategorySlug = command.CategorySlug;
                category.CategoryMetaTag = command.CategoryMetaTag;
                category.CategoryPageTittle = command.CategoryPageTittle;
                category.CategoryParentId = command.CategoryParentId;
                category.CategorySeohead = command.CategorySeohead;
                category.CategorySmallDescription = command.CategorySmallDescription;
                category.CategoryThumbPicUrl = command.NameImage;
                category.CategoryPicTitle = command.TitleImage;
                category.CategoryPicAlt = command.AltImage;
                category.CategoryPicDescription = command.DescImage;
                category.CategoryCanonicalAddress = command.CategoryCanonicalAddress;
                category.RegisteringEmployeeId = _authHelper.GetCurrnetUserInfo().AuthUserId;
                category.IsDeleted = command.IsDeleted;
                category.CategoryIcon = command.CategoryIcon;
                category.CategoryColor = command.CategoryColor;
                category.CategoryIsNew = command.CategoryIsNew;
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

        public IEnumerable<CategoryViewModel> GetParentCategories()
        {
            return _categoryRepository.GetParentCategories();
        }

        public IEnumerable<CategoryViewModel> GetChildCategories()
        {
            return _categoryRepository.GetChildCategories();
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
                var slugified = slug.GenerateSlug();
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

        public List<CategoryMenuViewModel> GetCategoriesForMenu()
        {
            return _categoryQuery.GetCategoriesForMenu();
        }

        public List<CategoryViewModel> GetCategoriesForSearch()
        {
            return _categoryQuery.GetCategoriesForSearch();
        }

        public CategoryViewDetailsViewModel GetCategoryViewDetails(int id, string province)
        {
            var category = _categoryQuery.GetCategoryViewDetails(id, province);
            return category;
        }
    }
}