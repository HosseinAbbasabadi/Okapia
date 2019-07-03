using System.Collections.Generic;
using System.Linq;
using Okapia.Application.Contracts;
using Okapia.Domain;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.ViewModels.City;

namespace Okapia.Application.Applications
{
    public class CityApplication : ICityApplication
    {
        private readonly ICityRepository _cityRepository;

        public CityApplication(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public List<PlaceViewModel> GetCitiesBy(int provintId)
        {
            var cities = _cityRepository.Get(c => c.ProvinceId == provintId);
            return MapCities(cities);
        }

        private static List<PlaceViewModel> MapCities(IEnumerable<City> cities)
        {
            return cities.Select(MapCity).ToList();
        }

        private static PlaceViewModel MapCity(City city)
        {
            return new PlaceViewModel
            {
                Id = city.Id,
                Name = city.Name
            };
        }
    }
}