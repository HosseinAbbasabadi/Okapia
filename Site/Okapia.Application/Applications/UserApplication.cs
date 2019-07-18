using System.Collections.Generic;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Contracts;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.User;

namespace Okapia.Application.Applications
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;

        public UserApplication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserViewModel GetUserDetails(long id, int roleId)
        {
            return _userRepository.GetUserDetails(id, roleId);
        }

        public List<UserViewModel> Search(UserSearchModel searchModel, out int recordCount)
        {
            return _userRepository.Search(searchModel, Constants.Roles.User.Id, out recordCount);
        }
    }
}