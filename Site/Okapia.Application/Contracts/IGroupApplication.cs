using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Group;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Group;

namespace Okapia.Application.Contracts
{
    public interface IGroupApplication
    {
        List<GroupViewModel> GetGroups();
        OperationResult Create(CreateGroup command);
        OperationResult Edit(EditGroup command);
        OperationResult Delete(int id);
        OperationResult AddUsersToGroup(int id, UserSearchModel searchModel);
        OperationResult Activate(int id);
        EditGroup GetGroupForDetails(int id);
        List<GroupViewModel> Search(GroupSearchModel searchModel, out int recordCount);
    }
}