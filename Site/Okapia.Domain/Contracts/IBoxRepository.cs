using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Box;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Box;

namespace Okapia.Domain.Contracts
{
    public interface IBoxRepository : IRepository<int, Box>
    {
        EditBox GetDetails(int id);
        Box GetWithBoxJobs(int id);
        List<BoxViewModel> Search(BoxSearchModel searchModel, out int recordCount);
    }
}