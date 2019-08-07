using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class PageSearchModel : BaseSerachModel
    {
        [Display(Name = "عنوان صفحه")] public string PageTittle { get; set; }
        [Display(Name = "رده صفحه")] public int PageCategoryId { get; set; }
        [Display(Name = "ایجاد کننده صفحه")] public int PageRegisteringEmployeeId { get; set; }
        [Display(Name = "از تاریخ ایجاد")] public string PageFromRegistrationDate { get; set; }
        public DateTime PageFromRegistrationDateG { get; set; }
        [Display(Name = "تا تاریخ ایجاد")] public string PageToRegistrationDate { get; set; }
        public DateTime PageToRegistrationDateG { get; set; }
        [Display(Name = "از تاریخ انتشار")] public string PageFromPublishDate { get; set; }
        public DateTime PageFromPublishDateG { get; set; }
        [Display(Name = "تا تاریخ انتشار")] public string PageToPublishDate { get; set; }
        public DateTime PageToPublishDateG { get; set; }
        [Display(Name = "جستجو در حذف شده ها")] public bool PageIsDeleted { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Employees { get; set; }
    }
}