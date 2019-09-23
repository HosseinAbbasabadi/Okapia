using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Faq;

namespace Okapia.Areas.Administrator.Models
{
    public class FaqIndexViewModel
    {
        public FaqSearchModel FaqSearchModel { get; set; }
        public List<FaqViewModel> FaqViewModels { get; set; }
    }
}
