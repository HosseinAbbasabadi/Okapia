using System;
using Framework;
using Microsoft.AspNetCore.Http;
using Okapia.Application.Contracts;
using Okapia.Domain;
using Okapia.Domain.Commands.User;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Application.Applications
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthInfoRepository _authInfoRepository;

        public UserApplication(IUserRepository userRepository, IAuthInfoRepository authInfoRepository)
        {
            _userRepository = userRepository;
            _authInfoRepository = authInfoRepository;
        }

        public OperationResult RegisterUser(CreateUser command)
        {
            var operationResult = new OperationResult("RegisterUser", "Users");
            try
            {
                var user = new User
                {
                    UserFirstName = command.Name,
                    UserLastName = command.Family,
                    UserAddress = command.Address,
                    UserEmail = command.Email,
                    UserCity = command.City,
                    UserProvince = command.Province,
                    UserBirthDate = DateTime.Now,
                    UserNationalCode = command.NationalCardNumber,
                    UserPhoneNumber = command.PhoneNumber,
                    UserPostalCode = command.Postalcode,
                    UserRegistrationDate = DateTime.Now,
                    UserIsActivated = true,
                    UserCustomerIntroductionLimit = 200
                };
                _userRepository.Create(user);
                _userRepository.SaveChanges();
                var authInfo = new AuthInfo
                {
                    Username = user.UserNationalCode,
                    Password = user.UserPhoneNumber,
                    ReferenceRecordId = user.UserId,
                    RoleId = 1
                };
                _authInfoRepository.Create(authInfo);
                _authInfoRepository.SaveChanges();
                operationResult.Success = true;
                operationResult.RecordId = user.UserId;
                operationResult.Message = "succeded";
                return operationResult;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return operationResult;
                throw;
            }
        }
    }
}