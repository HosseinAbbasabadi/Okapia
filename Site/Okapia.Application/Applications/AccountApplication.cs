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
    public class AccountApplication : IAccountApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IUserRepository _userRepository;
        private readonly IAuthInfoRepository _authInfoRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AccountApplication(IUserRepository userRepository, IAuthInfoRepository authInfoRepository,
            IAuthHelper authHelper, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _authInfoRepository = authInfoRepository;
            _authHelper = authHelper;
            _passwordHasher = passwordHasher;
        }

        public OperationResult Login(Login login)
        {
            var result = new OperationResult("AuthInfo", "Login");
            var auth = _authInfoRepository.Get(x => x.Username == login.Username, x => x.IsDeleted == false)
                .FirstOrDefault();
            if (auth == null)
            {
                result.Message = ApplicationMessages.UserNotExists;
                return result;
            }

            var verified = _passwordHasher.Check(auth.Password, login.Password);
            if (!verified.Verified)
            {
                result.Message = ApplicationMessages.IncorrectPassword;
                return result;
            }

            var userInfo = new UserInfoViewModel(auth.Id, auth.ReferenceRecordId, auth.Username, auth.Username,
                auth.RoleId);
            _authHelper.Signin(userInfo);
            result.Success = true;
            result.Message = ApplicationMessages.OperationSuccess;
            return result;
        }

        public OperationResult Register(CreateUser command)
        {
            var operationResult = new OperationResult("RegisterUser", "Users");
            try
            {
                if (_authInfoRepository.IsDuplicated(x => x.Username == command.NationalCardNumber))
                {
                    operationResult.Message = ApplicationMessages.DuplicatedUser;
                    return operationResult;
                }

                var hashedPassword = _passwordHasher.Hash(command.PhoneNumber);

                var authInfo = new AuthInfo
                {
                    Username = command.NationalCardNumber,
                    Password = hashedPassword,
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

                var userInfo = new UserInfoViewModel(authInfo.Id, user.UserId, user.UserFirstName, authInfo.Username,
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
                operationResult.Message = ApplicationMessages.SystemFailure;
                return operationResult;
            }
        }

        public void LogoutUser()
        {
            _authHelper.Signout();
        }

        public UserInfoViewModel GetAccountInfo()
        {
            return _authHelper.GetCurrnetUserInfo();
        }
    }
}