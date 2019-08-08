using System.Collections.Generic;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.Category;

namespace Okapia.Models
{
    public class MenuViewModel
    {
        public AccountViewModel AccountViewModel { get; set; }
        public List<CategoryMenuViewModel> CategoryMenuViewModels { get; set; }
    }
}
