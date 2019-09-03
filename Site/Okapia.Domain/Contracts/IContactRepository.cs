using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.Contact;

namespace Okapia.Domain.Contracts
{
    public interface IContactRepository : IRepository<int, Contact>
    {
        List<ContactViewModel> Search(ContactSearchModel searchModel, out int recordCount);
        ContactDetailsViewModel GetDetails(int id);
    }
}