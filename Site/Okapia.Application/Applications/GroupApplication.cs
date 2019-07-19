using System;
using System.Collections.Generic;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Group;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Group;

namespace Okapia.Application.Applications
{
    public class GroupApplication : IGroupApplication
    {
        private readonly IGroupRepository _groupRepository;

        public GroupApplication(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public List<GroupViewModel> GetGroups()
        {
            return _groupRepository.GetGroups();
        }

        public OperationResult Create(CreateGroup command)
        {
            var result = new OperationResult("Group", "Create");
            try
            {
                if (_groupRepository.IsDuplicated(x => x.GroupName == command.Name))
                {
                    result.Message = ApplicationMessages.DuplicatedRecord;
                    return result;
                }

                var group = new Group
                {
                    GroupName = command.Name,
                    GroupDescription = command.Description,
                    IsDeleted = false,
                    GroupCreationDate = DateTime.Now
                };
                _groupRepository.Create(group);
                _groupRepository.SaveChanges();
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

        public OperationResult Edit(EditGroup command)
        {
            var result = new OperationResult("Group", "Edit");
            try
            {
                var group = _groupRepository.GetGroup(command.Id);
                if (group == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                group.GroupName = command.Name;
                group.GroupDescription = command.Description;
                group.IsDeleted = command.IsDeleted;
                _groupRepository.Update(group);
                _groupRepository.SaveChanges();
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
            var result = new OperationResult("Group", "Delete");
            try
            {
                var group = _groupRepository.GetGroup(id);
                if (group == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                group.IsDeleted = true;
                _groupRepository.Update(group);
                _groupRepository.SaveChanges();
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
            var result = new OperationResult("Group", "Activation");
            try
            {
                var group = _groupRepository.GetGroup(id);
                if (group == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                group.IsDeleted = false;
                _groupRepository.Update(group);
                _groupRepository.SaveChanges();
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

        public EditGroup GetGroupForDetails(int id)
        {
            return _groupRepository.GetGroupForDetails(id);
        }

        public List<GroupViewModel> Search(GroupSearchModel searchModel, out int recordCount)
        {
            return _groupRepository.Search(searchModel, out recordCount);
        }
    }
}