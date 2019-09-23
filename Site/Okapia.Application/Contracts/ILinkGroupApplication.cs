using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.LinkGroup;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.LinkGroup;

namespace Okapia.Application.Contracts
{
    public interface ILinkGroupApplication
    {
        OperationResult Create(CreateLinkGroup command);
        OperationResult Edit(EditLinkGroup command);
        OperationResult Delete(int id);
        OperationResult Activate(int id);
        EditLinkGroup GetLinkGroupDetails(int id);
        List<LinkGroup> GetActiveLinkGroups();
        List<LinkGroupViewModel> Search(LinkGroupSearchModel searchModel, out int recordCount);

        //
        List<LinkGroupWithLinksViewModel> GetFooterLinkGroupsWithLinks();
    }
}