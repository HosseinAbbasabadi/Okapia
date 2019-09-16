using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Okapia.Domain.Models;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Domain.Commands.Box
{
    public class EditBox : CreateBox
    {
        public int BoxId { get; set; }

        [Display(Name = "آیا باکس فعال باشد؟")]
        public bool BoxIsEnabled { get; set; }

        public List<BoxJob> BoxJobs { get; set; }
        public List<JobViewModel> Jobs { get; set; }
    }
}