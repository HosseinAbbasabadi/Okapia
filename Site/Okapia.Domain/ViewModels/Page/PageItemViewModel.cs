namespace Okapia.Domain.ViewModels.Page
{
    public class PageItemViewModel
    {
        public long PageId { get; set; }
        public string PageTitle { get; set; }
        public string PageCategory { get; set; }
        public string PagePublishDate { get; set; }
        public int PageCommentsCount { get; set; }
        public string PageSmallDescription { get; set; }
        public string PagePicture { get; set; }
        public string PagePictureAlt { get; set; }
        public string PagePictureTitle { get; set; }
        public string PagePictureDescription { get; set; }
    }
}