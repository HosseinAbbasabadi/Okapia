using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.SeachModels
{
    public class JobSearchModel : BaseSerachModel
    {
        [Display(Name = "عنوان")]
        public string JobName { get; set; }
        [Display(Name = "نام رابط")]
        public string JobContactTitile { get; set; }
        [Display(Name = "نام مدیر")]
        public string JobManagerFirstName { get; set; }
        [Display(Name = "نام خانوادگی مدیر")]
        public string JobManagerLastName { get; set; }
        [Display(Name = "شماره تلفن")]
        public string JobTel1 { get; set; }
        [Display(Name = "شماره موبایل")]
        public string JobMobile1 { get; set; }
        [Display(Name = "استان")]
        public int JobProvienceId { get; set; }
        [Display(Name = "شهر")]
        public int JobCityId { get; set; }
        [Display(Name = "منطقه")]
        public int JobDistrictId { get; set; }
        [Display(Name = "محله")]
        public int JobNeighborhoodId { get; set; }

        public SelectList Proviences { get; set; }
    }
}
