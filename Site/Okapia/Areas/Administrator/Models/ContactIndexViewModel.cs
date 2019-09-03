using System.Collections.Generic;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels;

namespace Okapia.Areas.Administrator.Models
{
    public class ContactIndexViewModel
    {
        public ContactSearchModel ContactSearchModel { get; set; }
        public List<ContactViewModel> ContactViewModels { get; set; }
    }
}
