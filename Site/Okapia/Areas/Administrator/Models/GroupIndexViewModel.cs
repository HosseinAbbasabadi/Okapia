using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Group;

namespace Okapia.Areas.Administrator.Models
{
    public class GroupIndexViewModel
    {
        public GroupSearchModel GroupSearchModel { get; set; }
        public List<GroupViewModel> GroupViewModels { get; set; }
    }
}
