using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Marketer;

namespace Okapia.Areas.Administrator.Models
{
    public class MarketerIndexViewModel
    {
        public MarketerSearchModel MarketerSearchModel { get; set; }
        public List<MarketerViewModel> MarketerViewModels { get; set; }
    }
}