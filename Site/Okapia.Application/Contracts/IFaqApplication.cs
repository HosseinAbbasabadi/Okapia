using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Faq;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Faq;

namespace Okapia.Application.Contracts
{
    public interface IFaqApplication
    {
        OperationResult Create(CreateFaq command);
        OperationResult Edit(EditFaq command);
        OperationResult Delete(long id);
        OperationResult Activate(long id);
        EditFaq GetDetails(long id);
        List<FaqViewModel> Search(FaqSearchModel searchModel, out int recordCount);
    }
}
