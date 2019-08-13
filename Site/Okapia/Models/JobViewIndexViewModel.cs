using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Models
{
    public class JobViewIndexViewModel
    {
        public JobViewSearchModel JobViewSearchModel { get; set; }
        public List<JobItemViewModel> JobItemViewModels { get; set; }
    }
}
