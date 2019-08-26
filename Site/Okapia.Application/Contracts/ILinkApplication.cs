using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Link;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Link;

namespace Okapia.Application.Contracts
{
    public interface ILinkApplication
    {
        OperationResult Create(CreateLink command);
        OperationResult Update(EditLink command);
        OperationResult Delete(int id);
        OperationResult Activate(int id);
        List<LinkViewModel> Search(LinkSearchModel searchModel, out int recordCount);
        EditLink GetLinkDetails(int id);


        //
        List<LinkSiteViewModel> GetLinksForSite();
    }
}