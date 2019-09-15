using System;

namespace Okapia.Domain.Models
{
    public class Box
    {
        public int BoxId { get; set; }
        public string BoxTitle { get; set; }
        public string BoxLink { get; set; }
        public string BoxLinkText { get; set; }
        public string BoxLinkBtnText { get; set; }
        public string BoxColor { get; set; }
        public string BoxIcon { get; set; }
        public bool BoxIsEnabled { get; set; }
        public string BoxBannerPicture { get; set; }
        public string BoxBannerPictureLink { get; set; }
        public string BoxBannerPictureAlt { get; set; }
        public string BoxBannerPictureTitle { get; set; }
        public bool BoxBannerPictureIsEnabled { get; set; }
        public DateTime BoxCreationDate { get; set; }
        public long BoxCreatorAccountId { get; set; }
    }
}