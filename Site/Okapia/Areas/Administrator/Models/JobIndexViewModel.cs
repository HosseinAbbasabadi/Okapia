using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Areas.Administrator.Models
{
    public class JobIndexViewModel
    {
        public JobSearchModel JobSearchModel { get; set; }
        public IEnumerable<JobViewModel> JobViewModels { get; set; }
    }
}
