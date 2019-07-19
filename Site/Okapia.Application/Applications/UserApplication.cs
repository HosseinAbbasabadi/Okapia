using System;
using System.Collections.Generic;
using Framework;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.User;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.User;
using Okapia.Repository;

namespace Okapia.Application.Applications
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccountRepository _accountRepository;
        private readonly ICityApplication _cityApplication;
        private readonly IDistrictApplication _districtApplication;
        private readonly INeighborhoodApplication _neighborhoodApplication;

        public UserApplication(IUserRepository userRepository, IPasswordHasher passwordHasher,
            IAccountRepository accountRepository, ICityApplication cityApplication, IDistrictApplication districtApplication, INeighborhoodApplication neighborhoodApplication)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _accountRepository = accountRepository;
            _cityApplication = cityApplication;
            _districtApplication = districtApplication;
            _neighborhoodApplication = neighborhoodApplication;
        }

        public OperationResult Create(CreateUser command)
        {
            var result = new OperationResult("User", "Create");
            try
            {
                if (_accountRepository.IsDuplicated(x => x.Username == command.NationalCardNumber))
                {
                    result.Message = ApplicationMessages.DuplicatedUser;
                    return result;
                }

                var hashedPassword = _passwordHasher.Hash(command.PhoneNumber);
                var userCards = new List<UserCard>
                {
                    new UserCard
                    {
                        CardNumber = command.Card1
                    },
                    new UserCard
                    {
                        CardNumber = command.Card2
                    },
                    new UserCard
                    {
                        CardNumber = command.Card3
                    },
                    new UserCard
                    {
                        CardNumber = command.Card4
                    },
                    new UserCard
                    {
                        CardNumber = command.Card5
                    },
                    new UserCard
                    {
                        CardNumber = command.Card6
                    }
                };
                var account = new Account
                {
                    Username = command.NationalCardNumber,
                    Password = hashedPassword,
                    IsDeleted = false,
                    RoleId = Constants.Roles.User.Id
                };
                command.BirthDateG = command.BirthDate.ToGeorgianDateTime();
                var user = new User
                {
                    UserFirstName = command.Name,
                    UserLastName = command.Family,
                    UserAddress = command.Address,
                    UserEmail = command.Email,
                    UserCityId = command.CityId,
                    UserProvinceId = command.ProvinceId,
                    UserDistrictId = command.DistrictId,
                    UserNeighborhoodId = command.NeighborhoodId,
                    UserBirthDate = command.BirthDateG,
                    UserNationalCode = command.NationalCardNumber,
                    UserPhoneNumber = command.PhoneNumber,
                    UserPostalCode = command.Postalcode,
                    UserRegistrationDate = DateTime.Now,
                    UserIsActivated = true,
                    UserCustomerIntroductionLimit = 200,
                    Account = account,
                    UserCards = userCards
                };
                _userRepository.Create(user);
                _userRepository.SaveChanges();
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

        public OperationResult Edit(EditUser command)
        {
            var result = new OperationResult("User", "Edit");
            try
            {
                var user = _userRepository.GetUser(command.Id);
                var userAccount = user.Account;
                command.BirthDateG = command.BirthDate.ToGeorgianDateTime();

                userAccount.Username = command.Username;
                userAccount.IsDeleted = command.IsDeleted;
                userAccount.RoleId = Constants.Roles.User.Id;

                user.UserFirstName = command.Name;
                user.UserLastName = command.Family;
                user.UserAddress = command.Address;
                user.UserEmail = command.Email;
                user.UserCityId = command.CityId;
                user.UserProvinceId = command.ProvinceId;
                user.UserDistrictId = command.DistrictId;
                user.UserNeighborhoodId = command.NeighborhoodId;
                user.UserBirthDate = command.BirthDateG;
                user.UserNationalCode = command.NationalCardNumber;
                user.UserPhoneNumber = command.PhoneNumber;
                user.UserPostalCode = command.Postalcode;
                user.UserRegistrationDate = DateTime.Now;
                user.UserIsActivated = true;
                user.UserCustomerIntroductionLimit = 200;
                user.UserCards[0].CardNumber = command.Card1;
                user.UserCards[1].CardNumber = command.Card2;
                user.UserCards[2].CardNumber = command.Card3;
                user.UserCards[3].CardNumber = command.Card4;
                user.UserCards[4].CardNumber = command.Card5;
                user.UserCards[5].CardNumber = command.Card6;
                _userRepository.Update(user);
                _userRepository.SaveChanges();
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

        public EditUser GetUserDetails(long id)
        {
            var user = _userRepository.GetUserDetails(id);
            user.Cities=
                new SelectList(_cityApplication.GetCitiesBy(user.ProvinceId), "Id", "Name");
            user.Districts =
                new SelectList(_districtApplication.GetDistrictsBy(user.CityId), "Id", "Name");
            user.Neighborhoods =
                new SelectList(_neighborhoodApplication.GetNeighborhoodsBy(user.DistrictId), "Id", "Name");
            return user;
        }

        public List<UserViewModel> Search(UserSearchModel searchModel, out int recordCount)
        {
            return _userRepository.Search(searchModel, Constants.Roles.User.Id, out recordCount);
        }
    }
}