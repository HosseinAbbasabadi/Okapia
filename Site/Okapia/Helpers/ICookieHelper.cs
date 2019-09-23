namespace Okapia
{
    public interface ICookieHelper
    {
        string Get(string key);
        void Set(string key, string value);
    }
}