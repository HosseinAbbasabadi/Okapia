using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.Job
{
    public class JobViewModel
    {
        public long JobId { get; set; }
        [Display(Name = "عنوان")]
        public string JobName { get; set; }
        [Display(Name = "نام رابط")]
        public string JobContactTitile { get; set; }

        [Display(Name = "نام مدیر")]
        public string JobManagerFirstName { get; set; }

        [Display(Name = "نام خانوادگی مدیر")]
        public string JobManagerLastName { get; set; }
        [Display(Name = "شماره تلفن")]
        public string JobTel { get; set; }
        [Display(Name = "شماره موبایل")]
        public string JobMobile { get; set; }

        [Display(Name = "گروه شغل")]
        public string JobCategory { get; set; }
        public int JobCategoryId { get; set; }
        
        [Display(Name = "استان")]
        public string JobProvience { get; set; }
        public int JobProvienceId { get; set; }

        [Display(Name = "شهر")]
        public string JobCity { get; set; }
        public int JobCityId { get; set; }

        [Display(Name = "منطقه")]
        public string JobDistrict { get; set; }
        public int JobDistrictId { get; set; }

        [Display(Name = "محله")]
        public string JobNeighborhood { get; set; }
        public int JobNeighborhoodId { get; set; }

        [Display(Name = "عکس")]
        public string JobPicture { get; set; }

        [Display(Name = "حذف شده؟")]
        public bool IsDeleted { get; set; }

        public long AccountId { get; set; }
    }
}
