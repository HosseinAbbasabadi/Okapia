namespace Okapia.Domain.ViewModels.User
{
    public class UserInfoViewModel
    {
        public bool IsAuthorized { get; set; }

        public long UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public int Role { get; set; }

        public UserInfoViewModel()
        {
        }

        public UserInfoViewModel(long userId, string name, string username, int role)
        {
            UserId = userId;
            Name = name;
            Username = username;
            Role = role;
            IsAuthorized = true;
        }
    }
}