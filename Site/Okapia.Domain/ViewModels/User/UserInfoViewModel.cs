namespace Okapia.Domain.ViewModels.User
{
    public class UserInfoViewModel
    {
        public bool IsAuthorized { get; set; }

        public string Name { get; set; }
        public string Username { get; set; }
        public int Role { get; set; }

        public UserInfoViewModel()
        {
            
        }
        public UserInfoViewModel(string name, string username, int role)
        {
            Name = name;
            Username = username;
            Role = role;
            IsAuthorized = true;
        }
    }
}
