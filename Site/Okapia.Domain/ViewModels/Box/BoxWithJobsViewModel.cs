using System.Collections.Generic;
using Okapia.Domain.Models;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Domain.ViewModels.Box
{
    public class BoxWithJobsViewModel
    {
        public int BoxId { get; set; }
        public string BoxTitle { get; set; }
        public string BoxLink { get; set; }
        public string BoxLinkText { get; set; }
        public string BoxLinkBtnText { get; set; }
        public string BoxColor { get; set; }
        public string BoxIcon { get; set; }
        public string BoxBannerPicture { get; set; }
        public string BoxBannerPictureLink { get; set; }
        public string BoxBannerPictureAlt { get; set; }
        public string BoxBannerPictureTitle { get; set; }
        public bool BoxBannerPictureIsEnabled { get; set; }
        public string BoxProvinceName { get; set; }
        public List<BoxJob> BoxJobs { get; set; }
        public List<JobItemViewModel> Jobs { get; set; }
    }
}