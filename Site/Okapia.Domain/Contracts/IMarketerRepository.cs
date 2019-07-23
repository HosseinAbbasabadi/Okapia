using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Marketer;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Marketer;

namespace Okapia.Domain.Contracts
{
    public interface IMarketerRepository : IRepository<long, Marketer>
    {
        Marketer GetMarketer(long id);
        EditMarketer GetMarketerDetails(long id);
        List<MarketerViewModel> Search(MarketerSearchModel searchModel, out int recordCount);
    }
}