using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Link;

namespace Okapia.Areas.Administrator.Models
{
    public class LinkIndexViewModel
    {
        public LinkSearchModel LinkSearchModel { get; set; }
        public List<LinkViewModel> LinkViewModels { get; set; }
    }
}
