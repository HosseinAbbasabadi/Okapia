using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Page;

namespace Okapia.Areas.Administrator.Models
{
    public class PageIndexViewModel
    {
        public PageSearchModel PageSearchModel { get; set; }
        public List<PageViewModel> PageViewModels { get; set; }
    }
}
