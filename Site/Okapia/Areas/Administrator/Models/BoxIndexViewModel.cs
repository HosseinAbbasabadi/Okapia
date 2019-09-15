using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Box;

namespace Okapia.Areas.Administrator.Models
{
    public class BoxIndexViewModel
    {
        public BoxSearchModel BoxSearchModel { get; set; }
        public List<BoxViewModel> BoxViewModels { get; set; }
    }
}
