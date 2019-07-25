using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.User;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.User;

namespace Okapia.Application.Contracts
{
    public interface IUserApplication
    {
        OperationResult Create(CreateUser command);
        OperationResult Edit(EditUser command);
        //OperationResult SendUsersToGroup(long id, UserSearchModel searchModel);
        EditUser GetUserDetails(long id);
        List<UserViewModel> Search(UserSearchModel searchModel, out int recordCount);
    }
}
