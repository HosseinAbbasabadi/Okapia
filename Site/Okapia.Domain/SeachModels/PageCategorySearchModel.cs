using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class PageCategorySearchModel : BaseSerachModel
    {
        [Display(Name = "نام")]
        public string PageCategoryName { get; set; }
        [Display(Name = "رده مافوق")]
        public int PageCategoryParentId { get; set; }
        [Display(Name = "کاربر ثبت کننده")]
        public int PageCategoryRegisteringEmployeId { get; set; }
        [Display(Name = "جستجو در حذف شده ها")]
        public bool PageCategoryIsDeleted { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Employees { get; set; }
    }
}