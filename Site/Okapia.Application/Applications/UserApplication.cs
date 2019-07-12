using System;
using System.Linq;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.User;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.ViewModels.User;

namespace Okapia.Application.Applications
{
    public class UserApplication : IUserApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IUserRepository _userRepository;
        private readonly IAuthInfoRepository _authInfoRepository;

        public UserApplication(IUserRepository userRepository, IAuthInfoRepository authInfoRepository,
            IAuthHelper authHelper)
        {
            _userRepository = userRepository;
            _authInfoRepository = authInfoRepository;
            _authHelper = authHelper;
        }

        public OperationResult LoginUser(Login login)
        {
            var result = new OperationResult("AuthInfo", "Login");
            var auth = _authInfoRepository.Get(x => x.Username == login.Username, x => x.Password == login.Password,
                    x => x.IsDeleted == false)
                .FirstOrDefault();
            if (auth != null)
            {
                var userInfo = new UserInfoViewModel(auth.Id, auth.Username, auth.Username, auth.RoleId);
                _authHelper.Signin(userInfo);
                result.Success = true;
                result.Message = ApplicationMessages.OperationSuccess;
                return result;
            }

            result.Message = ApplicationMessages.UserNotExists;
            return result;
        }

        public OperationResult RegisterUser(CreateUser command)
        {
            var operationResult = new OperationResult("RegisterUser", "Users");
            try
            {
                if (_authInfoRepository.IsDuplicated(x => x.Username == command.NationalCardNumber))
                {
                    operationResult.Message = ApplicationMessages.DuplicatedUser;
                    return operationResult;
                }

                var authInfo = new AuthInfo
                {
                    Username = command.NationalCardNumber,
                    Password = command.PhoneNumber,
                    //ReferenceRecordId = user.UserId,
                    RoleId = Constants.Roles.User.Id,
                    IsDeleted = false
                };

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
                    UserCustomerIntroductionLimit = 200,
                    AuthInfo = authInfo
                };
                _userRepository.Create(user);
                _userRepository.SaveChanges();
               
                //_authInfoRepository.Create(authInfo);
                //_authInfoRepository.SaveChanges();
                var userInfo = new UserInfoViewModel(authInfo.Id, command.Name, authInfo.Username,
                    Constants.Roles.User.Id);
                _authHelper.Signin(userInfo);
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

        public void LogoutUser()
        {
            _authHelper.Signout();
        }

        public UserInfoViewModel GetUserInfo()
        {
            return _authHelper.GetCurrnetUserInfo();
        }
    }
}