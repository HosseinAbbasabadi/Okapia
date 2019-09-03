using System.Collections.Generic;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.PageCategory;

namespace Okapia.Models
{
    public class PageCategoryMenuIndexViewModel
    {
        public AccountViewModel AccountViewModel { get; set; }
        public List<PageCategoryMenuViewModel> PageCategoryMenuViewModels { get; set; }
    }
}
