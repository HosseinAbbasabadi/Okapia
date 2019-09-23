using System;
using System.Collections.Generic;
using System.Text;

namespace Okapia.Domain.ViewModels.Job
{
    public class JobSearchResultViewModel
    {
        public string JobName { get; set; }
        public string JobSlug { get; set; }
        public string JobUrl { get; set; }
        public string JobPicture { get; set; }
        public string JobPictureUrl { get; set; }
        public string Province { get; set; }
    }
}
