using System.Collections.Generic;
using System.Linq;
using Okapia.Application.Contracts;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.ViewModels.City;

namespace Okapia.Application.Applications
{
    public class DistrictApplication : IDistrictApplication
    {
        private readonly IDistrictRepository _districtRepository;

        public DistrictApplication(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public List<PlaceViewModel> GetDistrictsBy(int cityId)
        {
            var districts = _districtRepository.Get(c => c.CityId == cityId);
            return MapDistricts(districts);
        }

        private static List<PlaceViewModel> MapDistricts(IEnumerable<District> districts)
        {
            return districts.Select(MapDistrict).ToList();
        }

        private static PlaceViewModel MapDistrict(District district)
        {
            return new PlaceViewModel
            {
                Id = district.Id,
                Name = district.Name
            };
        }
    }
}