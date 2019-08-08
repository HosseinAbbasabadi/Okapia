namespace Okapia.Domain.Models
{
    public class UserCard
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public string CardNumber { get; set; }
    }
}
