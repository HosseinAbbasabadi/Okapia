using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Marketer;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Marketer;

namespace Okapia.Application.Applications
{
    public class MarketerApplication : IMarketerApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IMarketerRepository _marketerRepository;
        private readonly ICityApplication _cityApplication;
        private readonly IDistrictApplication _districtApplication;
        private readonly INeighborhoodApplication _neighborhoodApplication;

        public MarketerApplication(IMarketerRepository marketerRepository, IAuthHelper authHelper,
            ICityApplication cityApplication, IDistrictApplication districtApplication,
            INeighborhoodApplication neighborhoodApplication)
        {
            _marketerRepository = marketerRepository;
            _authHelper = authHelper;
            _cityApplication = cityApplication;
            _districtApplication = districtApplication;
            _neighborhoodApplication = neighborhoodApplication;
        }

        public OperationResult Create(CreateMarketer command)
        {
            var result = new OperationResult("Marketers", "Create");
            try
            {
                if (!command.MarketerNationalCode.IsValidNationalCode())
                {
                    result.Message = ApplicationMessages.InvalidNationalCode;
                    return result;
                }

                if (_marketerRepository.IsDuplicated(x => x.MarketerNationalCode == command.MarketerNationalCode))
                {
                    result.Message = ApplicationMessages.DuplicatedRecord;
                    return result;
                }

                var marketer = new Marketer
                {
                    MarketerFirstName = command.MarketerFirstName,
                    MarketerLastName = command.MarketerLastName,
                    MarketerNationalCode = command.MarketerNationalCode,
                    MarketerMobile = command.MarketerMobile,
                    MarketerProvinceId = command.MarketerProvinceId,
                    MarketerCityId = command.MarketerCityId,
                    MarketerDistrictId = command.MarketerDistrictId,
                    MarketerNeighborhoodId = command.MarketerNeighborhoodId,
                    MarketerCreationDate = DateTime.Now,
                    MarketerCreatorEmployeeId = _authHelper.GetCurrnetUserInfo().AuthUserId,
                    MarketerIsDeleted = false
                };

                _marketerRepository.Create(marketer);
                _marketerRepository.SaveChanges();
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

        public OperationResult Edit(EditMarketer command)
        {
            var result = new OperationResult("Marketers", "Edit");
            try
            {
                if (!_marketerRepository.Exists(x => x.MarketerId == command.MarketerId))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var marketer = _marketerRepository.GetMarketer(command.MarketerId);
                marketer.MarketerFirstName = command.MarketerFirstName;
                marketer.MarketerLastName = command.MarketerLastName;
                marketer.MarketerNationalCode = command.MarketerNationalCode;
                marketer.MarketerMobile = command.MarketerMobile;
                marketer.MarketerProvinceId = command.MarketerProvinceId;
                marketer.MarketerCityId = command.MarketerCityId;
                marketer.MarketerDistrictId = command.MarketerDistrictId;
                marketer.MarketerNeighborhoodId = command.MarketerNeighborhoodId;
                marketer.MarketerIsDeleted = command.MarketerIsDeleted;
                _marketerRepository.Update(marketer);
                _marketerRepository.SaveChanges();
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

        public OperationResult Delete(long id)
        {
            var result = new OperationResult("Marketer", "Delete");
            try
            {
                if (!_marketerRepository.Exists(x => x.MarketerId == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var marketer = _marketerRepository.GetMarketer(id);
                marketer.MarketerIsDeleted = true;
                _marketerRepository.Update(marketer);
                _marketerRepository.SaveChanges();
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

        public OperationResult Activate(long id)
        {
            var result = new OperationResult("Marketer", "Delete");
            try
            {
                if (!_marketerRepository.Exists(x => x.MarketerId == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var marketer = _marketerRepository.GetMarketer(id);
                marketer.MarketerIsDeleted = false;
                _marketerRepository.Update(marketer);
                _marketerRepository.SaveChanges();
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

        public EditMarketer GetMarketerDetails(long id)
        {
            var marketerDetails = _marketerRepository.GetMarketerDetails(id);
            var cities = _cityApplication.GetCitiesBy(marketerDetails.MarketerProvinceId);
            var districts = _districtApplication.GetDistrictsBy(marketerDetails.MarketerCityId);
            var neighborhoods = _neighborhoodApplication.GetNeighborhoodsBy(marketerDetails.MarketerDistrictId);
            marketerDetails.Cities = new SelectList(cities, "Id", "Name");
            marketerDetails.Districts = new SelectList(districts, "Id", "Name");
            marketerDetails.Neighborhoods = new SelectList(neighborhoods, "Id", "Name");
            return marketerDetails;
        }

        public List<MarketerViewModel> GetMarketers()
        {
            return _marketerRepository.Get(x => x.MarketerIsDeleted == false).Select(x => new MarketerViewModel
            {
                MarketerId = x.MarketerId,
                MarketerFullName = x.MarketerFirstName + " " + x.MarketerLastName
            }).ToList();
        }

        public List<MarketerViewModel> Search(MarketerSearchModel searchModel, out int recordCount)
        {
            return _marketerRepository.Search(searchModel, out recordCount);
        }
    }
}