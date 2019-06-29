namespace Okapia.Domain.SeachModels
{
    public class BaseSerachModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int RecordCount { get; set; }
    }
}
