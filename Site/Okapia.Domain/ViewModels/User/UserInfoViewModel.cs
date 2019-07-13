namespace Okapia.Domain.ViewModels.User
{
    public class UserInfoViewModel
    {
        public bool IsAuthorized { get; set; }

        public long AuthUserId { get; set; }
        public long ReferenceRecordId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public int Role { get; set; }

        public UserInfoViewModel()
        {
        }

        public UserInfoViewModel(long authUserId, long referenceRecordId, string name, string username, int role)
        {
            AuthUserId = authUserId;
            ReferenceRecordId = referenceRecordId;
            Name = name;
            Username = username;
            Role = role;
            IsAuthorized = true;
        }
    }
}