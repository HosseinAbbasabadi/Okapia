using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Slide;

namespace Okapia.Areas.Administrator.Models
{
    public class SlideIndexViewModel
    {
        public SlideSearchModel SlideSearchModel { get; set; }
        public List<SlideViewModel> SlideViewModels { get; set; }
    }
}
