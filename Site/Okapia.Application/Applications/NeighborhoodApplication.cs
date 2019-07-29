﻿using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Neighborhood;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.City;
using Okapia.Domain.ViewModels.Neighborhood;

namespace Okapia.Application.Applications
{
    public class
        NeighborhoodApplication : INeighborhoodApplication
    {
        private readonly INeighborhoodRepository _neighborhoodRepository;
        private readonly ICityApplication _cityApplication;
        private readonly IDistrictApplication _districtApplication;

        public NeighborhoodApplication(INeighborhoodRepository neighborhoodRepository, ICityApplication cityApplication,
            IDistrictApplication districtApplication)
        {
            _neighborhoodRepository = neighborhoodRepository;
            _cityApplication = cityApplication;
            _districtApplication = districtApplication;
        }

        public OperationResult Create(CreateNeighborhood command)
        {
            var result = new OperationResult("Neighborhood", "Create");
            try
            {
                if (_neighborhoodRepository.IsDuplicated(x => x.Name == command.Name,
                    x => x.DistrictId == command.CityId))
                {
                    result.Message = ApplicationMessages.DuplicatedRecord;
                    return result;
                }

                var neighborhood = new Neighborhood
                {
                    Name = command.Name,
                    DistrictId = command.DistrictId,
                    IsDeleted = false
                };
                _neighborhoodRepository.Create(neighborhood);
                _neighborhoodRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public OperationResult Update(EditNeighborhood command)
        {
            var result = new OperationResult("Neighborhood", "Update");
            try
            {
                var neighborhood = new Neighborhood
                {
                    Id = command.Id,
                    Name = command.Name,
                    DistrictId = command.DistrictId,
                    IsDeleted = command.IsDeleted
                };
                _neighborhoodRepository.Update(neighborhood);
                _neighborhoodRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var neighborhood = _neighborhoodRepository.GetNeighborhood(id);
                neighborhood.IsDeleted = true;
                _neighborhoodRepository.SaveChanges();
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
                var neighborhood = _neighborhoodRepository.GetNeighborhood(id);
                neighborhood.IsDeleted = false;
                _neighborhoodRepository.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public EditNeighborhood GetNeighborhoodDetails(int id)
        {
            var neighborhood = _neighborhoodRepository.GetNeighborhoodDetails(id);
            var cities = _cityApplication.GetCitiesBy(neighborhood.ProvinceId);
            var districts = _districtApplication.GetDistrictsBy(neighborhood.CityId);
            neighborhood.Cities = new SelectList(cities, "Id", "Name");
            neighborhood.Districts = new SelectList(districts, "Id", "Name");
            return neighborhood;
        }

        public List<PlaceViewModel> GetNeighborhoodsBy(int districtId)
        {
            var neighborhoods = _neighborhoodRepository.Get(n => n.DistrictId == districtId, n => n.IsDeleted == false);
            return MapDistricts(neighborhoods);
        }

        public List<NeighborhoodViewModel> GetNeighborhoodsForList(NeighborhoodSearchModel searchModel,
            out int recordCount)
        {
            return _neighborhoodRepository.Search(searchModel, out recordCount);
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