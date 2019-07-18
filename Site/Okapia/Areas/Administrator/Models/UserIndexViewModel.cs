using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.User;

namespace Okapia.Areas.Administrator.Models
{
    public class UserIndexViewModel
    {
        public UserSearchModel UserSearchModel { get; set; }
        public List<UserViewModel> UserViewModels { get; set; }
    }
}
