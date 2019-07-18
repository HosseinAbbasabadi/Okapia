using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.User;

namespace Okapia.Domain.Contracts
{
    public interface IUserRepository : IRepository<long, User>
    {
        UserViewModel GetUserDetails(long id, int roleId);
        List<UserViewModel> Search(UserSearchModel searchModel, int roleId, out int recordCount);
    }
}