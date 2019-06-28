using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okapia.Application.SeachModels;
using Okapia.Application.ViewModels.Job;

namespace Okapia.Areas.Administrator.Models
{
    public class JobIndexViewModel
    {
        public JobSearchModel JobSearchModel { get; set; }
        public IEnumerable<JobViewModel> JobViewModels { get; set; }
    }
}
