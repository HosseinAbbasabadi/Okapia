using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Domain.ViewModels.JobPicture;

namespace Okapia.Domain.Commands.Job
{
    public class EditJob : CreateJob
    {
        public int JobId { get; set; }
        [Display(Name = "آیا صفحه حذف شود؟")] public bool IsDeleted { get; set; }
        public string JobCategory { get; set; }
        public string JobProvience { get; set; }
        public string JobCity { get; set; }
        public string JobDistrict { get; set; }
        public string JobNeighborhood { get; set; }

        [Display(Name = "آدرس صفحه جایگزین در صورت حذف")]
        public string RedirectInstead301Url { get; set; }
        public new List<JobPictureViewModel> Photos { get; set; }
        public SelectList Citeies { get; set; }
        public SelectList Districts { get; set; }
        public SelectList Neighborhoods { get; set; }
    }
}