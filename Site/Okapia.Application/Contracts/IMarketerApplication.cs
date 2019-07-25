using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Marketer;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Marketer;

namespace Okapia.Application.Contracts
{
    public interface IMarketerApplication
    {
        OperationResult Create(CreateMarketer command);
        OperationResult Edit(EditMarketer command);
        OperationResult Delete(long id);
        OperationResult Activate(long id);
        EditMarketer GetMarketerDetails(long id);
        List<MarketerViewModel> GetMarketers();
        List<MarketerViewModel> Search(MarketerSearchModel searchModel, out int recordCount);
    }
}