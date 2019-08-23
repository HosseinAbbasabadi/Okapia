namespace Okapia.Domain.ViewModels.Job
{
    public class JobStaredViewModel
    {
        public long JobId { get; set; }
        public string JobSlug { get; set; }
        public string JobName { get; set; }
        public string JobSmallDescription { get; set; }
        public string JobPictureName { get; set; }
        public string JobPictureAlt { get; set; }
        public string JobPictureTitle { get; set; }
    }
}