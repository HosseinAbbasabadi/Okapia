using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.RequestJob;

namespace Okapia.Areas.Administrator.Models
{
    public class JobRequestIndexViewModel
    {
        public JobRequestSearchModel JobRequestSearchModel { get; set; }
        public List<JobRequestViewModel> JobRequestViewModels { get; set; }
    }
}
