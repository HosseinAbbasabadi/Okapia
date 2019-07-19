using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Modal;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Modal;

namespace Okapia.Application.Contracts
{
    public interface IModalApplication
    {
        OperationResult Create(CreateModal command);
        OperationResult Edit(EditModal command);
        OperationResult Delete(int id);
        OperationResult Activate(int id);
        EditModal GetModalDetails(int id);
        List<ModalViewModel> Search(ModalSearchModel searchModel, out int recordCount);
    }
}