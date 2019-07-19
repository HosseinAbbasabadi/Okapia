using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.Modal;

namespace Okapia.Areas.Administrator.Models
{
    public class ModalIndexViewModel
    {
        public ModalSearchModel ModalSearchModel { get; set; }
        public List<ModalViewModel> ModalViewModels { get; set; }
    }
}
