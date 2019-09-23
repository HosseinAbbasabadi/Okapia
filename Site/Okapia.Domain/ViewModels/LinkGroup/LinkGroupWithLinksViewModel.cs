using System.Collections.Generic;
using Okapia.Domain.ViewModels.Link;

namespace Okapia.Domain.ViewModels.LinkGroup
{
    public class LinkGroupWithLinksViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LinkViewModel> Links { get; set; }
    }
}