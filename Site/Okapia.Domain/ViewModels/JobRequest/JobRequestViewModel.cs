using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.JobRequest
{
    public class JobRequestViewModel
    {
        public long Id { get; set; }
        [Display(Name = "عنوان شغلی")] public string Name { get; set; }
        [Display(Name = "نام رابط")] public string ContactTitle { get; set; }
        [Display(Name = "موبایل")] public string Mobile { get; set; }
        [Display(Name = "تفلن ثابت")] public string Tel { get; set; }
        public int ProvinceId { get; set; }
        [Display(Name = "استان")] public string Province { get; set; }
        public int CityId { get; set; }
        [Display(Name = "شهر")] public string City { get; set; }
        [Display(Name = "وضعیت")] public int Status { get; set; }
        [Display(Name = "شماره پیگیری")] public long TrackingNumber { get; set; }
        [Display(Name = "تاریخ درخواست")] public string CreationDate { get; set; }
        [Display(Name = "آدرس")] public string Address { get; set; }
        [Display(Name = "توضیحات")] public string Description { get; set; }
    }
}