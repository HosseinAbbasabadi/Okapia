﻿namespace Okapia.Domain.Models
{
    public class JobPicture
    {
        public int JobPictureId { get; set; }
        public string JobPictureTitle { get; set; }
        public string JobPictureSmallDescription { get; set; }
        public string JobPictureAlt { get; set; }
        public string JobPicturThumbUrl { get; set; }
        public string JobPictureUrl { get; set; }
        public bool IsDefault { get; set; }
        public int? JobPictureSortOrder { get; set; }
        public long JobId { get; set; }
        public virtual Job Job { get; set; }
    }
}