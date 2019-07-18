namespace Okapia.Domain.ViewModels
{
    public class AccountViewModel
    {
        public bool IsAuthorized { get; set; }

        public long AuthUserId { get; set; }
        public long ReferenceRecordId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public int Role { get; set; }

        public AccountViewModel()
        {
        }

        public AccountViewModel(long authUserId, long referenceRecordId, string name, string username, int role)
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