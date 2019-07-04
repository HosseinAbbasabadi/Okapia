using System;
using System.Collections.Generic;
using System.Linq;
using Okapia.Application.Contracts;
using Okapia.Domain.Commands.City;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
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

        public void Create(CreateCity command)
        {
            try
            {
                var city = new City
                {
                    Name = command.Name,
                    ProvinceId = command.ProvinceId,
                    IsDeleted = false
                };
                _cityRepository.Create(city);
                _cityRepository.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var city = _cityRepository.GetCity(id);
                city.IsDeleted = true;
                _cityRepository.Update(city);
                _cityRepository.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void Activate(int id)
        {
            try
            {
                var city = _cityRepository.GetCity(id);
                city.IsDeleted = false;
                _cityRepository.Update(city);
                _cityRepository.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void Update(EditCity command)
        {
            try
            {
                var city = new City
                {
                    Id = command.Id,
                    Name = command.Name,
                    IsDeleted = command.IsDeleted,
                    ProvinceId = command.ProvinceId
                };
                _cityRepository.Update(city);
                _cityRepository.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public EditCity GetCityDetails(int id)
        {
            try
            {
                return _cityRepository.GetCityDetails(id);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public List<CityViewModel> GetCitiesForList(CitySearchModel searchModel, out int recordCount)
        {
            return _cityRepository.Search(searchModel, out recordCount);
        }

        public List<CityViewModel> GetCitiesBy(int provintId)
        {
            var cities = _cityRepository.Get(c => c.ProvinceId == provintId, c => c.IsDeleted == false);
            return MapCities(cities);
        }

        private static List<CityViewModel> MapCities(IEnumerable<City> cities)
        {
            return cities.Select(MapCity).ToList();
        }

        private static CityViewModel MapCity(City city)
        {
            return new CityViewModel
            {
                Id = city.Id,
                Name = city.Name,
                IsDeleted = city.IsDeleted,
                ProvinceId = city.ProvinceId
            };
        }
    }
}