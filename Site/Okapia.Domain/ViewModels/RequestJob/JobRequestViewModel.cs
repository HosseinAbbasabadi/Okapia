using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Okapia.Domain.ViewModels.RequestJob
{
    public class JobRequestViewModel
    {
        public long Id { get; set; }
        [Display(Name = "عنوان شغلی")]
        public string Name { get; set; }
        [Display(Name = "نام رابط")]
        public string ContactTitle { get; set; }
        [Display(Name = "موبایل")]
        public string Mobile { get; set; }
        [Display(Name = "تفلن ثابت")]
        public string Tel { get; set; }    
        public int ProvinceId { get; set; }
        [Display(Name = "استان")]
        public string Province { get; set; }
        public int CityId { get; set; }
        [Display(Name = "شهر")]
        public string City { get; set; }
        [Display(Name = "وضعیت")]
        public int Status { get; set; }
        [Display(Name = "شماره پیگیری")]
        public long TrackingNumber { get; set; }
    }
}
