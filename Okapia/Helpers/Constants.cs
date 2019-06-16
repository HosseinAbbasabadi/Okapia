namespace Okapia.Helpers
{
    public static class Constants
    {
        public static Roles Roles { get; } = new Roles();
        public static Cookies Cookies { get; } = new Cookies();
        public static Names Names { get; } = new Names();
    }

    public class Roles
    {
        public string Administrator { get; } = "Administrator";
        public string Customer { get; } = "Customer";
        public string ShopKeeper { get; } = "Job";
        public string Club { get; } = "Club";
    }

    public class Cookies
    {
        public string AuthecticationCookieName { get; } = "Okapia_Authentication";
        public string RoleCookieName { get; } = "Okapia_Role";
        public string UsernameCookieName { get; } = "Okapia_Username";
    }

    public class Names
    {
        public string Ali { get; } = "Ali";
        public string Hasan { get; } = "Hasan";
        public string Hossein { get; } = "Hossein";
        public string Mahdi { get; } = "Mahdi";
    }
}