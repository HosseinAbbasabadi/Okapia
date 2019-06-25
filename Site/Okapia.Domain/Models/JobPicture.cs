namespace Okapia.Domain.Models
{
    public partial class JobPicture
    {
        public int JobPictureId { get; set; }
        public string JobPictureTitle { get; set; }
        public string JobPictureSmallDescription { get; set; }
        public string JobPictureAlt { get; set; }
        public string JobPicturThumbUrl { get; set; }
        public string JobPictureUrl { get; set; }
        public int? JobPictureSortOrder { get; set; }
        public int JobId { get; set; }

        public virtual Jobs Job { get; set; }
    }
}