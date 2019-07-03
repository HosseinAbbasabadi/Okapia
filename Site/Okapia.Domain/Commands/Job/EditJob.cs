using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int NamePhoto1Id { get; set; }
        public int NamePhoto2Id { get; set; }
        public int NamePhoto3Id { get; set; }
        public int NamePhoto4Id { get; set; }
        public int NamePhoto5Id { get; set; }
        public int NamePhoto6Id { get; set; }
        public new List<JobPictureViewModel> Photos { get; set; }
    }
}