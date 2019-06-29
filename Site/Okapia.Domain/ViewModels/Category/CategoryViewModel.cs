using System;
using System.Collections.Generic;
using System.Text;

namespace Okapia.Domain.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CatgoryName { get; set; }
        public string CategorySmallDescription { get; set; }
        public int CategoryParentName { get; set; }
    }
}
