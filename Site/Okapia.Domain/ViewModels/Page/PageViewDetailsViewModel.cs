using System.Collections.Generic;
using Okapia.Domain.ViewModels.Comment;

namespace Okapia.Domain.ViewModels.Page
{
    public class PageViewDetailsViewModel
    {
        public long PageId { get; set; }
        public string PageSlug { get; set; }
        public string PageTitle { get; set; }
        public int PageCategoryId { get; set; }
        public string PageCategory { get; set; }
        public string PagePublishDate { get; set; }
        public int PageCommentsCount { get; set; }
        public string PageSmallDescription { get; set; }
        public string PagePicture { get; set; }
        public string PagePictureAlt { get; set; }
        public string PagePictureTitle { get; set; }
        public string PagePictureDescription { get; set; }
        public string PageDescription { get; set; }
        public string PageMetaDescription { get; set; }
        public string PageCanonicalAddress { get; set; }
        public string PageMetaTag { get; set; }
        public List<string> MetaTags { get; set; }
        public List<CommentItemViewModel> Comments { get; set; }
    }
}
