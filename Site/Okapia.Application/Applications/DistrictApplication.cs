using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.District;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.City;
using Okapia.Domain.ViewModels.District;

namespace Okapia.Application.Applications
{
    public class DistrictApplication : IDistrictApplication
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly ICityApplication _cityApplication;

        public DistrictApplication(IDistrictRepository districtRepository, ICityApplication cityApplication)
        {
            _districtRepository = districtRepository;
            _cityApplication = cityApplication;
        }

        public OperationResult Create(CreateDistrict command)
        {
            var result = new OperationResult("District", "Create");
            try
            {
                if (_districtRepository.IsDuplicated(x => x.Name == command.Name, x => x.CityId == command.CityId))
                {
                    result.Message = ApplicationMessages.DuplicatedRecord;
                    return result;
                }

                var district = new District
                {
                    Name = command.Name,
                    CityId = command.CityId,
                    IsDeleted = false
                };
                _districtRepository.Create(district);
                _districtRepository.SaveChanges();
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

        public OperationResult Update(EditDistrict command)
        {
            var result = new OperationResult("District", "Update");
            try
            {
                var district = new District
                {
                    Id = command.Id,
                    Name = command.Name,
                    CityId = command.CityId,
                    IsDeleted = command.IsDeleted
                };
                _districtRepository.Update(district);
                _districtRepository.SaveChanges();
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
            var district = _districtRepository.GetDistrict(id);
            district.IsDeleted = true;
            _districtRepository.Update(district);
            _districtRepository.SaveChanges();
        }

        public void Activate(int id)
        {
            var district = _districtRepository.GetDistrict(id);
            district.IsDeleted = false;
            _districtRepository.Update(district);
            _districtRepository.SaveChanges();
        }

        public EditDistrict GetDistrictDitails(int id)
        {
            var district = _districtRepository.GetDistrictDetails(id);
            var cities = _cityApplication.GetCitiesBy(district.ProvinceId);
            district.Cities = new SelectList(cities, "Id", "Name");
            return district;
        }

        public List<PlaceViewModel> GetDistrictsBy(int cityId)
        {
            var districts = _districtRepository.Get(c => c.CityId == cityId, c => c.IsDeleted == false);
            return MapDistricts(districts);
        }

        public List<DistrictViewModel> GetDistrictsForList(DistrictSearchModel searchModel, out int recordCount)
        {
            return _districtRepository.Search(searchModel, out recordCount);
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