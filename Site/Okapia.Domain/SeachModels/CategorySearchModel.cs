using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.SeachModels
{
    public class CategorySearchModel : BaseSerachModel
    {
        [Display(Name = "نام")]
        public string CategoryName { get; set; }
        [Display(Name = "عنوان گروه مافوق")]
        public int CategoryParrentId { get; set; }
        public SelectList Categories { get; set; }
    }
}
