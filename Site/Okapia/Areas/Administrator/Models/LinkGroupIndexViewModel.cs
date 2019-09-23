using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.LinkGroup;

namespace Okapia.Areas.Administrator.Models
{
    public class LinkGroupIndexViewModel
    {
        public LinkGroupSearchModel LinkGroupSearchModel { get; set; }
        public List<LinkGroupViewModel> LinkGroupViewModels { get; set; }
    }
}
