using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Box;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Box;

namespace Okapia.Application.Contracts
{
    public interface IBoxApplication
    {
        OperationResult Create(CreateBox command);
        OperationResult Edit(EditBox command);
        OperationResult Activate(int id);
        OperationResult Deactive(int id);
        EditBox GetDetails(int id);
        List<BoxViewModel> GetActiveBoxes();
        OperationResult RemoveJobFromBox(int boxId, long jobId);
        List<BoxViewModel> Search(BoxSearchModel searchModel, out int recordCount);

        //
        List<BoxWithJobsViewModel> GetBoxesForLandingPage(string province);
    }
}