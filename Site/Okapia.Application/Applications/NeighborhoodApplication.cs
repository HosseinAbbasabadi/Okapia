using System.Collections.Generic;
using System.Linq;
using Okapia.Application.Contracts;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.ViewModels.City;

namespace Okapia.Application.Applications
{
    public class NeighborhoodApplication : INeighborhoodApplication
    {
        private readonly INeighborhoodRepository _neighborhoodRepository;

        public NeighborhoodApplication(INeighborhoodRepository neighborhoodRepository)
        {
            _neighborhoodRepository = neighborhoodRepository;
        }

        public List<PlaceViewModel> GetNeighborhoodsBy(int districtId)
        {
            var neighborhoods = _neighborhoodRepository.Get(n => n.DistrictId == districtId);
            return MapDistricts(neighborhoods);
        }

        private static List<PlaceViewModel> MapDistricts(IEnumerable<Neighborhood> neighborhoods)
        {
            return neighborhoods.Select(MapNeighborhood).ToList();
        }

        private static PlaceViewModel MapNeighborhood(Neighborhood neighborhood)
        {
            return new PlaceViewModel
            {
                Id = neighborhood.Id,
                Name = neighborhood.Name
            };
        }
    }
}