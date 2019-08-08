using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Okapia.Domain.ViewModels.Category
{
    public class CategoryMenuViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Photo { get; set; }
        public List<CategoryMenuViewModel> CategoryChilds { get; set; }
    }
}
