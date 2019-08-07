using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Page;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Page;

namespace Okapia.Application.Contracts
{
    public interface IPageApplication
    {
        OperationResult Create(CreatePage command);
        OperationResult Edit(EditPage command);
        OperationResult Delete(long id);
        OperationResult Activate(long id);
        EditPage GetPageDetails(long id);
        List<PageViewModel> Search(PageSearchModel searchModel, out int recordCount);
    }
}
