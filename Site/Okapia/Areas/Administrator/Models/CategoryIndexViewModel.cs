using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Category;

namespace Okapia.Areas.Administrator.Models
{
    public class CategoryIndexViewModel
    {
        public CategorySearchModel CategorySearchModel { get; set; }
        public IEnumerable<CategoryViewModel> CategoryViewModels { get; set; }
    }
}
