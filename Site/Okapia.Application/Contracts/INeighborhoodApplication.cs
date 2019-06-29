using System.Collections.Generic;
using Okapia.Domain.ViewModels.City;

namespace Okapia.Application.Contracts
{
    public interface INeighborhoodApplication
    {
        List<PlaceViewModel> GetNeighborhoodsBy(int districtId);
    }
}