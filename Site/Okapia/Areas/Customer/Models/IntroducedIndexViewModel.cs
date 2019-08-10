using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.User;

namespace Okapia.Areas.Customer.Models
{
    public class IntroducedIndexViewModel
    {
        public IntroducedSearchModel IntroducedSearchModel { get; set; }
        public List<IntroducedViewModel> IntroducedViewModels { get; set; }
    }
}
