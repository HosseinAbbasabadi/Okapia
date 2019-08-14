using System.Collections.Generic;
using Okapia.Domain.ViewModels.Comment;
using Okapia.Domain.ViewModels.JobPicture;

namespace Okapia.Domain.ViewModels.Job
{
    public class JobViewDetailsViewModel
    {
        public long JobId { get; set; }
        public string JobName { get; set; }
        public double JobBenefitPercentForEndCustomer { get; set; }
        public string JobFeatures { get; set; }
        public List<string> JobFeatureList { get; set; }
        public string JobSmallDescription { get; set; }
        public string JobDescription { get; set; }
        public string JobAddress { get; set; }
        public string JobTel1 { get; set; }
        public string JobTel2 { get; set; }
        public string JobMobile1 { get; set; }
        public string JobMobile2 { get; set; }
        public string JobProvience { get; set; }
        public string JobCity { get; set; }
        public string JobDistrict { get; set; }
        public string JobNeighborhood { get; set; }
        public string JobWazeMap { get; set; }
        public string JobWazeLink { get; set; }
        public string JobPageTittle { get; set; }
        public string JobSlug { get; set; }
        public string JobMetaTag { get; set; }
        public string JobMetaDesccription { get; set; }
        public string JobSeohead { get; set; }
        public bool IsWebsite { get; set; }
        public string WebsiteUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TelegramUrl { get; set; }
        public List<JobPictureViewModel> Photos { get; set; }
        public List<CommentItemViewModel> Comments { get; set; }
    }
}