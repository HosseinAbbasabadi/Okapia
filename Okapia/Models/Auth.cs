namespace Okapia.Models
{
    public class Auth
    {
        public bool IsAuthorized { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public Auth()
        {
            
        }
        public Auth(bool isAuthorized, string username, string role)
        {
            IsAuthorized = isAuthorized;
            Username = username;
            Role = role;
        }
    }
}
