using System;
using System.Collections.Generic;
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
            var editMarketer = _marketerRepository.GetMarketerDetails(id);
            var cities = _cityApplication.GetCitiesBy(editMarketer.MarketerProvinceId);
            var districts = _districtApplication.GetDistrictsBy(editMarketer.MarketerCityId);
            var neighborhoods = _neighborhoodApplication.GetNeighborhoodsBy(editMarketer.MarketerDistrictId);
            editMarketer.Cities = new SelectList(cities, "Id", "Name");
            editMarketer.Districts = new SelectList(districts, "Id", "Name");
            editMarketer.Neighborhoods=new SelectList(neighborhoods, "Id", "Name");
            return editMarketer;
        }

        public List<MarketerViewModel> Search(MarketerSearchModel searchModel, out int recordCount)
        {
            return _marketerRepository.Search(searchModel, out recordCount);
        }
    }
}