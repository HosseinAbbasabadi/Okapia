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
        OperationResult Introduce(CreateUser command);
        OperationResult Edit(EditUser command);
        OperationResult EditByUser(EditUser command);
        OperationResult MakeUserMarketer(long accountId);
        //OperationResult SendUsersToGroup(long id, UserSearchModel searchModel);
        EditUser GetUserDetails(long id);
        UserDetailsViewModel GetUserInfo(long id);
        List<UserViewModel> Search(UserSearchModel searchModel, out int recordCount);
        List<IntroducedViewModel> SearchIntroduced(IntroducedSearchModel searchModel, out int recordCount);

        //
        long GetActiveUsersCount();
    }
}