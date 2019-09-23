using System;
using System.Collections.Generic;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.LinkGroup;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.LinkGroup;

namespace Okapia.Application.Applications
{
    public class LinkGroupApplication : ILinkGroupApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly ILinkGroupQuery _linkGroupQuery;
        private readonly ILinkGroupRepository _linkGroupRepository;

        public LinkGroupApplication(ILinkGroupRepository linkGroupRepository, ILinkGroupQuery linkGroupQuery,
            IAuthHelper authHelper)
        {
            _linkGroupRepository = linkGroupRepository;
            _linkGroupQuery = linkGroupQuery;
            _authHelper = authHelper;
        }

        public OperationResult Create(CreateLinkGroup command)
        {
            var result = new OperationResult("LinkGroups", "Create");
            try
            {
                if (_linkGroupRepository.IsDuplicated(x => x.Name == command.Name))
                {
                    result.Message = ApplicationMessages.DuplicatedRecord;
                    return result;
                }

                var linkGroup = new LinkGroup
                {
                    Name = command.Name,
                    CreationDate = DateTime.Now,
                    CreatorAccountId = _authHelper.GetCurrnetUserInfo().AuthUserId,
                    IsDeleted = false
                };

                _linkGroupRepository.Create(linkGroup);
                _linkGroupRepository.SaveChanges();
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

        public OperationResult Edit(EditLinkGroup command)
        {
            var result = new OperationResult("LinkGroups", "Create");
            try
            {
                var linkGroup = _linkGroupRepository.Get(command.Id);
                if (linkGroup == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                linkGroup.Name = command.Name;
                linkGroup.IsDeleted = command.IsDeleted;
                _linkGroupRepository.SaveChanges();
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
            var result = new OperationResult("LinkGroups", "Create");
            try
            {
                var linkGroup = _linkGroupRepository.Get(id);
                if (linkGroup == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                linkGroup.IsDeleted = true;
                _linkGroupRepository.SaveChanges();
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
            var result = new OperationResult("LinkGroups", "Create");
            try
            {
                var linkGroup = _linkGroupRepository.Get(id);
                if (linkGroup == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                linkGroup.IsDeleted = false;
                _linkGroupRepository.SaveChanges();
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

        public EditLinkGroup GetLinkGroupDetails(int id)
        {
            throw new NotImplementedException();
        }

        public List<LinkGroup> GetActiveLinkGroups()
        {
            return _linkGroupRepository.Get(x => !x.IsDeleted);
        }

        public List<LinkGroupViewModel> Search(LinkGroupSearchModel searchModel, out int recordCount)
        {
            return _linkGroupRepository.Search(searchModel, out recordCount);
        }

        public List<LinkGroupWithLinksViewModel> GetFooterLinkGroupsWithLinks()
        {
            return _linkGroupQuery.GetFooterLinkGroupsWithLinks();
        }
    }
}