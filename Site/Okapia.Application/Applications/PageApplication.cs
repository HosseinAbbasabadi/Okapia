using System;
using System.Collections.Generic;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Page;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Page;

namespace Okapia.Application.Applications
{
    public class PageApplication : IPageApplication
    {
        private readonly IPageRepository _pageRepository;
        private readonly IAuthHelper _authHelper;

        public PageApplication(IPageRepository pageRepository, IAuthHelper authHelper)
        {
            _pageRepository = pageRepository;
            _authHelper = authHelper;
        }

        public OperationResult Create(CreatePage command)
        {
            var result = new OperationResult("Pages", "Create");
            try
            {
                if (_pageRepository.IsDuplicated(x => x.PageTittle == command.PageTitle))
                {
                    result.Message = ApplicationMessages.DuplicatedRecord;
                    return result;
                }

                if (_pageRepository.IsDuplicated(x => x.PageSlug == command.PageSlug))
                {
                    result.Message = ApplicationMessages.DuplicatedSlug;
                    return result;
                }

                if (!string.IsNullOrEmpty(command.PagePublishDate))
                    command.PagePublishDateG = command.PagePublishDate.ToGeorgianDateTime();

                var page = new Page
                {
                    PageTittle = command.PageTitle,
                    PageCanonicalAddress = command.PageCanonicalAddress,
                    PageCategoryId = command.PageCategoryId,
                    PageContent = command.Content,
                    PageIsDeleted = false,
                    PageMetaDesccription = command.PageMetaDesccription,
                    PageMetaTag = command.PageMetaTag,
                    PagePublishDate = command.PagePublishDateG,
                    PageRegistrationDate = DateTime.Now,
                    PageSeohead = command.PageSeohead,
                    PageSlug = command.PageSlug,
                    PageSmallDescription = command.PageSmallDescription,
                    PageRegisteringEmployeeId = _authHelper.GetCurrnetUserInfo().AuthUserId
                };
                _pageRepository.Create(page);
                _pageRepository.SaveChanges();
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

        public OperationResult Edit(EditPage command)
        {
            var result = new OperationResult("Pages", "Edit");
            try
            {
                if (!_pageRepository.Exists(x => x.PageId == command.PageId))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var page = _pageRepository.Get(command.PageId);
                page.PageTittle = command.PageTitle;
                page.PagePublishDate = command.PagePublishDate.ToGeorgianDateTime();
                page.PageCategoryId = command.PageCategoryId;
                page.PageContent = command.Content;
                page.PageMetaDesccription = command.PageMetaDesccription;
                page.PageMetaTag = command.PageMetaTag;
                page.PageRemoved301InsteadUrl = command.PageRemoved301InsteadUrl;
                page.PageSeohead = command.PageSeohead;
                page.PageCanonicalAddress = command.PageCanonicalAddress;
                page.PageIsDeleted = command.PageIsDeleted;
                page.PageSlug = command.PageSlug;
                page.PageSmallDescription = command.PageSmallDescription;
                _pageRepository.SaveChanges();
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

        public OperationResult Delete(long id)
        {
            var result = new OperationResult("Pages", "Delete");
            try
            {
                if (!_pageRepository.Exists(x => x.PageId == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var page = _pageRepository.Get(id);
                page.PageIsDeleted = true;
                _pageRepository.SaveChanges();
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

        public OperationResult Activate(long id)
        {
            var result = new OperationResult("Pages", "Delete");
            try
            {
                if (!_pageRepository.Exists(x => x.PageId == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var page = _pageRepository.Get(id);
                page.PageIsDeleted = false;
                _pageRepository.SaveChanges();
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

        public OperationResult CheckSlugDuplication(string slug)
        {
            var result = new OperationResult("Pages", "CheckSlugDuplication");
            try
            {
                var slugified = slug.GenerateSlug();
                if (_pageRepository.Exists(x => x.PageSlug == slugified))
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

        public EditPage GetPageDetails(long id)
        {
            return _pageRepository.GetPageDetails(id);
        }

        public List<PageViewModel> Search(PageSearchModel searchModel, out int recordCount)
        {
            if (!string.IsNullOrEmpty(searchModel.PageFromRegistrationDate))
                searchModel.PageFromRegistrationDateG = searchModel.PageFromRegistrationDate.ToGeorgianDateTime();
            if (!string.IsNullOrEmpty(searchModel.PageToRegistrationDate))
                searchModel.PageToRegistrationDateG = searchModel.PageToRegistrationDate.ToGeorgianDateTime();
            if (!string.IsNullOrEmpty(searchModel.PageFromPublishDate))
                searchModel.PageFromPublishDateG = searchModel.PageFromPublishDate.ToGeorgianDateTime();
            if (!string.IsNullOrEmpty(searchModel.PageToPublishDate))
                searchModel.PageToPublishDateG = searchModel.PageToPublishDate.ToGeorgianDateTime();
            return _pageRepository.Search(searchModel, out recordCount);
        }
    }
}