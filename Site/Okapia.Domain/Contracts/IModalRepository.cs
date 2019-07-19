using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Modal;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Modal;

namespace Okapia.Domain.Contracts
{
    public interface IModalRepository : IRepository<int, Modal>
    {
        Modal GetModal(int id);
        EditModal GetModalDetails(int id);
        List<ModalViewModel> Search(ModalSearchModel searchModel, out int recordCount);
    }
}
