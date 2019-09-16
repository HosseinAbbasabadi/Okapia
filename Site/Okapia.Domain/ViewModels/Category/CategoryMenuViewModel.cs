using System.Collections.Generic;

namespace Okapia.Domain.ViewModels.Category
{
    public class CategoryMenuViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public string Photo { get; set; }
        public string PhotoAlt { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public bool IsNew { get; set; }
        public List<CategoryMenuViewModel> CategoryChilds { get; set; }
    }
}
