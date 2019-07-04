using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Neighborhood;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Neighborhood;

namespace Okapia.Domain.Contracts
{
    public interface INeighborhoodRepository : IRepository<int, Neighborhood>
    {
        Neighborhood GetNeighborhood(int id);
        EditNeighborhood GetNeighborhoodDetails(int id);
        List<NeighborhoodViewModel> Search(NeighborhoodSearchModel searchModel, out int recordCount);
    }
}