using System;
using System.Collections.Generic;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.PageCategory;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.PageCategory;

namespace Okapia.Application.Applications
{
    public class PageCategoryApplication : IPageCategoryApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IPageCategoryRepository _pageCategoryRepository;
        private readonly IPageCategoryQuery _pageCategoryQuery;

        public PageCategoryApplication(IPageCategoryRepository pageCategoryRepository, IAuthHelper authHelper, IPageCategoryQuery pageCategoryQuery)
        {
            _pageCategoryRepository = pageCategoryRepository;
            _authHelper = authHelper;
            _pageCategoryQuery = pageCategoryQuery;
        }

        public OperationResult Create(CreatePageCategory command)
        {
            var result = new OperationResult("PageCategory", "Create");
            try
            {
                if (_pageCategoryRepository.IsDuplicated(x => x.PageCategoryName == command.PageCategoryPageTitle))
                {
                    result.Message = ApplicationMessages.DuplicatedRecord;
                    return result;
                }

                var pageCategory = new PageCategory
                {
                    PageCanonicalAddress = command.PageCanonicalAddress,
                    PageCategoryMetaDesccription = command.PageCategoryMetaDesccription,
                    PageCategoryMetaTag = command.PageCategoryMetaTag,
                    PageCategoryName = command.PageCategoryName,
                    PageCategoryPageTitle = command.PageCategoryPageTitle,
                    PageCategoryParentId = command.PageCategoryParentId,
                    PageCategorySeohead = command.PageCategorySeohead,
                    PageCategoryShowOrder = command.PageCategoryShowOrder,
                    PageCategorySlug = command.PageCategorySlug,
                    PageCategorySmallPictutre = command.NameImage,
                    PageCategorySmallPictutreAlt = command.AltImage,
                    PageCategorySmallPictutreDescription = command.DescImage,
                    PageCategorySmallPictutreTitle = command.TitleImage,
                    PageCategoryRegisteringEmployeId = _authHelper.GetCurrnetUserInfo().AuthUserId,
                    PageCategoryRegistrationDate = DateTime.Now,
                    PageCategoryIsDeleted = false
                };
                _pageCategoryRepository.Create(pageCategory);
                _pageCategoryRepository.SaveChanges();
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

        public OperationResult Edit(EditPageCategory command)
        {
            var result = new OperationResult("PageCategory", "Edit");
            try
            {

                if (!_pageCategoryRepository.Exists(x => x.PageCategoryId == command.PageCategoryId))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var pageCategory = _pageCategoryRepository.Get(command.PageCategoryId);
                pageCategory.PageCategoryMetaDesccription = command.PageCategoryMetaDesccription;
                pageCategory.PageCategoryMetaTag = command.PageCategoryMetaTag;
                pageCategory.PageCategoryParentId = command.PageCategoryParentId;
                pageCategory.PageCategoryRemoved301InsteadUrl = command.PageCategoryRemoved301InsteadUrl;
                pageCategory.PageCategorySeohead = command.PageCategorySeohead;
                pageCategory.PageCategoryShowOrder = command.PageCategoryShowOrder;
                pageCategory.PageCategorySlug = command.PageCategorySlug;
                pageCategory.PageCategorySmallPictutre = command.NameImage;
                pageCategory.PageCategorySmallPictutreAlt = command.AltImage;
                pageCategory.PageCategorySmallPictutreDescription = command.DescImage;
                pageCategory.PageCategorySmallPictutreTitle = command.TitleImage;
                pageCategory.PageCategoryPageTitle = command.PageCategoryPageTitle;
                pageCategory.PageCanonicalAddress = command.PageCanonicalAddress;
                pageCategory.PageCategoryIsDeleted = command.PageCategoryIsDeleted;
                pageCategory.PageCategoryName = command.PageCategoryName;
                _pageCategoryRepository.SaveChanges();
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

        public OperationResult Delete(int id)
        {
            var result = new OperationResult("PageCategory", "Delete");
            try
            {
                if (!_pageCategoryRepository.Exists(x => x.PageCategoryId == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var pageCategory = _pageCategoryRepository.Get(id);
                pageCategory.PageCategoryIsDeleted = true;
                _pageCategoryRepository.SaveChanges();
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

        public OperationResult Activate(int id)
        {
            var result = new OperationResult("PageCategory", "Activate");
            try
            {
                if (!_pageCategoryRepository.Exists(x => x.PageCategoryId == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var pageCategory = _pageCategoryRepository.Get(id);
                pageCategory.PageCategoryIsDeleted = false;
                _pageCategoryRepository.SaveChanges();
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

        public EditPageCategory GetPageCategoryDetails(int id)
        {
            return _pageCategoryRepository.GetPageCategoryDetails(id);
        }

        public List<PageCategoryViewModel> GetPageCategories()
        {
            return _pageCategoryRepository.GetPageCategories();
        }

        public List<PageCategoryViewModel> Search(PageCategorySearchModel searchModel, out int recordCount)
        {
            return _pageCategoryRepository.Search(searchModel, out recordCount);
        }

        public OperationResult CheckSlugDuplication(string slug)
        {
            var result = new OperationResult("PageCategory", "CheckSlugDuplication");
            try
            {
                var slugified = slug.GenerateSlug();
                if (_pageCategoryRepository.Exists(x => x.PageCategorySlug == slugified))
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

        public List<PageCategoryItemViewModel> GetPageCategoriesForFooter()
        {
            return _pageCategoryQuery.GetPageCategoriesForFooter();
        }

        public PageCategoryBlogViewModel GetPageCategoryForBlog(string categorySlug)
        {
            return _pageCategoryQuery.GetPageCategoryForBlog(categorySlug);
        }
    }
}