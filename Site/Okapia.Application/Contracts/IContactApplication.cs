using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Contactus;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.Contact;

namespace Okapia.Application.Contracts
{
    public interface IContactApplication
    {
        List<ContactViewModel> Search(ContactSearchModel searchModel, out int recordCount);
        OperationResult Create(CreateContact command);
        OperationResult Check(int id);
        ContactDetailsViewModel GetDetails(int id);
    }
}