using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class JobSearchModel : BaseSerachModel
    {
        [Display(Name = "عنوان")] public string JobName { get; set; }
        [Display(Name = "نام رابط")] public string JobContactTitile { get; set; }
        [Display(Name = "نام مدیر")] public string JobManagerFirstName { get; set; }
        [Display(Name = "نام خانوادگی مدیر")] public string JobManagerLastName { get; set; }
        [Display(Name = "شماره تلفن")] public string JobTel { get; set; }
        [Display(Name = "شماره موبایل")] public string JobMobile { get; set; }
        [Display(Name = "گروه شغل")] public int JobCategoryId { get; set; }
        [Display(Name = "استان")] public int JobProvienceId { get; set; }
        [Display(Name = "شهر")] public int JobCityId { get; set; }
        [Display(Name = "منطقه")] public int JobDistrictId { get; set; }
        [Display(Name = "محله")] public int JobNeighborhoodId { get; set; }

        [Display(Name = "جستجو در حذف شده ها")]
        public bool IsDeleted { get; set; }

        [Display(Name = "جستجو در آیتم های صفحه اصلی")]
        public bool IsStared { get; set; }

        public SelectList Proviences { get; set; }
        public SelectList Categories { get; set; }
    }
}