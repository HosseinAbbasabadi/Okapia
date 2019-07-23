using System;
using System.ComponentModel.DataAnnotations;

namespace Okapia.Areas.Administrator.Models
{
    public class Page
    {
        [Display(Name = "شماره")] public int PageId { get; set; }

        [Display(Name = "گروه")] public int PageCategoryId { get; set; }

        [Display(Name = "عنوان صفحه")] public string PageTittle { get; set; }

        [Display(Name = "اسلاگ")] public string PageSlug { get; set; }

        [Display(Name = "تگ ها")] public string PageMetaTag { get; set; }

        [Display(Name = "توضیحات")] public string PageMetaDesccription { get; set; }

        [Display(Name = "هد سثو")] public string PageSeohead { get; set; }

        [Display(Name = "آدرس کنونیکال")] public string PageCanonicalAddress { get; set; }

        [Display(Name = "آیا حذف شده است")] public bool? PageIsDeleted { get; set; }

        [Display(Name = "آدرس صفحه جایگزین در صورت حذف صفحه")]
        public string PageRemoved301InsteadUrl { get; set; }

        [Display(Name = "توضیحات کوتاه")] public string PageSmallDescription { get; set; }

        [Display(Name = "محتویات صفحه")] public string PageContent { get; set; }

        [Display(Name = "ایجاد کننده صفحه")] public int PageRegisteringEmployeeId { get; set; }

        [Display(Name = "تاریخ ایجاد")] public DateTime PageRegistrationDate { get; set; }
    }
}