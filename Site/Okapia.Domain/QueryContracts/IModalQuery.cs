using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.ViewModels.Modal;

namespace Okapia.Domain.QueryContracts
{
    public interface IModalQuery : IRepository<int, Modal>
    {
        List<ModalShowViewModel> GetUserModals(long userId);
    }
}