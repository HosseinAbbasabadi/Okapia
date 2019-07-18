using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.User;

namespace Okapia.Application.Contracts
{
    public interface IUserApplication
    {
        UserViewModel GetUserDetails(long id, int roleId);
        List<UserViewModel> Search(UserSearchModel searchModel, out int recordCount);
    }
}
