using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.Job
{
    public class JobViewModel
    {
        public int JobId { get; set; }
        [Display(Name = "عنوان")]
        public string JobName { get; set; }
        [Display(Name = "نام رابط")]
        public string JobContactTitile { get; set; }

        [Display(Name = "نام مدیر")]
        public string JobManagerFirstName { get; set; }

        [Display(Name = "نام خانوادگی مدیر")]
        public string JobManagerLastName { get; set; }

        [Display(Name = "استان")]
        public string JobProvience { get; set; }

        [Display(Name = "شهر")]
        public string JobCity { get; set; }

        [Display(Name = "منطقه")]
        public string JobDistrict { get; set; }

        [Display(Name = "محله")]
        public string JobNeighborhood { get; set; }
    }
}
