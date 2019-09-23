using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class FaqSearchModel : BaseSerachModel
    {
        [Display(Name = "پرسش")] public string Question { get; set; }
        [Display(Name = "شغل مربوطه")] public long JobId { get; set; }

        [Display(Name = "جستجو در حذف شده ها")]
        public bool IsDeleted { get; set; }

        public SelectList Jobs { get; set; }
    }
}