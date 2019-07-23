using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Marketer;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Marketer;

namespace Okapia.Application.Contracts
{
    public interface IMarketerApplication
    {
        OperationResult Create(CreateMarketer command);
        EditMarketer GetMarketerDetails(long id);
        List<MarketerViewModel> Search(MarketerSearchModel searchModel, out int recordCount);
    }
}