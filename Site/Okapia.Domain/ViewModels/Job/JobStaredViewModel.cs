using System;
using System.Collections.Generic;
using System.Text;

namespace Okapia.Domain.ViewModels.Job
{
    public class JobStaredViewModel
    {
        public long JobId { get; set; }
        public string JobName { get; set; }
        public string JobSmallDescription { get; set; }
        public string JobPictureName { get; set; }
        public string JobPictureAlt { get; set; }
    }
}