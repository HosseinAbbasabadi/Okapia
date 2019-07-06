using System.Collections.Generic;
using Okapia.Domain.Commands.Neighborhood;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.City;
using Okapia.Domain.ViewModels.Neighborhood;

namespace Okapia.Application.Contracts
{
    public interface INeighborhoodApplication
    {
        void Create(CreateNeighborhood command);
        void Update(EditNeighborhood command);
        void Delete(int id);
        void Activate(int id);
        EditNeighborhood GetNeighborhoodDetails(int id);
        List<PlaceViewModel> GetNeighborhoodsBy(int districtId);
        List<NeighborhoodViewModel> GetNeighborhoodsForList(NeighborhoodSearchModel searchModel, out int recordCount);
    }
}