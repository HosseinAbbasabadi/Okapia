namespace Okapia.Domain.Models
{
    public class AuthInfo
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public long ReferenceRecordId { get; set; }
        public string RefereshToken { get; set; }
        public bool IsDeleted { get; set; }
    }
}