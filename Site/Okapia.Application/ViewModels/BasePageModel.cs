namespace Okapia.Application.ViewModels
{
    public class BasePageModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int RecordCount { get; set; }
    }
}
