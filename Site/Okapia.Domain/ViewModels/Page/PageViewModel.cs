using System;
using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.ViewModels.Page
{
    public class PageViewModel
    {
        public long PageId { get; set; }
        [Display(Name = "عنوان صفحه")] public string PageTitle { get; set; }
        public int PageCategoryId { get; set; }
        [Display(Name = "رده")] public string PageCategory { get; set; }
        public long PageRegisteringEmployeeId { get; set; }
        [Display(Name = "ایجاد کننده صفحه")] public string PageRegisteringEmployee { get; set; }
        [Display(Name = "تاریخ ایجاد")] public string PageRegistrationDate { get; set; }
        public DateTime PageRegistrationDateG { get; set; }
        [Display(Name = "تاریخ انتشار")] public string PagePublishDate { get; set; }
        public DateTime PagePublishDateG { get; set; }
        [Display(Name = "تعداد کامنت ها")] public int PageCommentsCount { get; set; }
        [Display(Name = "عکس")] public string PagePicture { get; set; }
        public bool PageIsDeleted { get; set; }
    }
}