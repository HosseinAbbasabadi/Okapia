using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.PageCategory;

namespace Okapia.Areas.Administrator.Models
{
    public class PageCategoryIndexViewModel
    {
        public PageCategorySearchModel PageCategorySearchModel { get; set; }
        public List<PageCategoryViewModel> PageCategoryViewModels { get; set; }
    }
}
