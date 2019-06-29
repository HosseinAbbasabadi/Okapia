namespace Okapia.Application.Utilities
{
    public static class FileManager
    {
        public static bool IsValidFileName(this string fileName)
        {            
            fileName = fileName.ToLower();
            return !fileName.Contains(".exe") && !fileName.Contains(".bat") && !fileName.Contains(".php") && !fileName.Contains(".asp") && !fileName.Contains(".rb") && !fileName.Contains(".py") && !fileName.Contains(".jsp") && !fileName.Contains(".sql") && !fileName.Contains(".js");
        }
    }
}
