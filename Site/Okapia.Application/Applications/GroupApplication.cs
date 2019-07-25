using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Group;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Group;
using Okapia.Domain.ViewModels.User;

namespace Okapia.Application.Applications
{
    public class GroupApplication : IGroupApplication
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserGroupRepository _userGroupRepository;

        public GroupApplication(IGroupRepository groupRepository, IUserRepository userRepository,
            IUserGroupRepository userGroupRepository)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
            _userGroupRepository = userGroupRepository;
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

        public OperationResult AddUsersToGroup(int id, UserSearchModel searchModel)
        {
            var result = new OperationResult("Users", "SendUsersToGroup");
            try
            {
                if (!_groupRepository.Exists(x => x.GroupId == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                searchModel.PageSize = int.MaxValue;
                var users = _userRepository.Search(searchModel);
                var group = _groupRepository.GetGroup(id);
                var userGroups = MapUsersToUserGroups(group, users);
                group.UserGroups = userGroups;
                //users.ForEach(x =>
                //{
                //    _userRepository.Detach(x.UserId);
                //    _userGroupRepository.Detach(group.GroupId, x.UserId);
                //});
                //_groupRepository.Detach(id);
                //_groupRepository.Attach(group);
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

        private static ICollection<UserGroup> MapUsersToUserGroups(Group group, IEnumerable<User> users)
        {
            var userGroups = group.UserGroups;
            foreach (var user in users)
            {
                var userGroup = new UserGroup
                {
                    User = user,
                    Group = group
                };
                if (group.UserGroups.Count != 0)
                {
                    var exists = group.UserGroups.Where(x => x.UserId == user.UserId)
                        .FirstOrDefault(x => x.GroupId == group.GroupId);
                    if (exists == null)
                        userGroups.Add(userGroup);
                }
                else
                {
                    userGroups.Add(userGroup);
                }
            }

            return userGroups;
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