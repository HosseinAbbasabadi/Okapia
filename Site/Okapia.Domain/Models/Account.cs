namespace Okapia.Domain.Models
{
    public class Account
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public long ReferenceRecordId { get; set; }
        public string RefereshToken { get; set; }
        public bool IsDeleted { get; set; }
        public Employee Employee { get; set; }
        public User User { get; set; }
        public Job Job { get; set; }
    }
}