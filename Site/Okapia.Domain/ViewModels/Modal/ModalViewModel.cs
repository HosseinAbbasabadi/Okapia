using System;
using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.Modal
{
    public class ModalViewModel
    {
        public int ModalId { get; set; }
        [Display(Name = "عنوان")] public string ModalTitle { get; set; }
        [Display(Name = "متن پیام")] public string ModalMessage { get; set; }
        [Display(Name = "لینک")] public string ModalPageLink { get; set; }
        [Display(Name = "عکس")] public string ModalPic { get; set; }
        public int ModalGroupId { get; set; }
        [Display(Name = "گروه")] public string ModalGroup { get; set; }
        [Display(Name = "تاریخ شروع")] public string ModalStartDate { get; set; }
        public DateTime ModalStartDateG { get; set; }
        [Display(Name = "تاریخ پایان")] public string ModalEndDate { get; set; }
        public DateTime ModalEndDateG { get; set; }
        public bool IsDeleted { get; set; }
    }
}