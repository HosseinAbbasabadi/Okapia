using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Group;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Group;

namespace Okapia.Domain.Contracts
{
    public interface IGroupRepository : IRepository<int, Group>
    {
        Group GetGroup(int id);
        EditGroup GetGroupForDetails(int id);
        List<GroupViewModel> Search(GroupSearchModel searchModel, out int recordCount);
    }
}
