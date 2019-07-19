using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class ModalSearchModel : BaseSerachModel
    {
        [Display(Name = "عنوان")]
        public string ModalTitle { get; set; }
        [Display(Name = "گروه مشتریان")]
        public int ModalGroupId { get; set; }
        [Display(Name = "جستجو در حذف شده ها")]
        public bool IsDeleted { get; set; }
        [Display(Name = "تاریخ شروع")]
        public string ModalStartDate { get; set; }
        [Display(Name = "تاریخ پایان")]
        public string ModalEndDate { get; set; }

        public DateTime ModalStartDateG { get; set; }
        public DateTime ModalEndDateG { get; set; }

        public SelectList Groups { get; set; }
    }
}
