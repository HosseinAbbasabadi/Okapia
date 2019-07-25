using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.User;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.User;

namespace Okapia.Domain.Contracts
{
    public interface IUserRepository : IRepository<long, User>
    {
        User GetUser(long id);
        EditUser GetUserDetails(long id);
        void Detach(long id);
        List<User> Search(UserSearchModel searchModel);
        List<UserViewModel> Search(UserSearchModel searchModel, out int recordCount);
    }
}