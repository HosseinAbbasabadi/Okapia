using System;
using System.Linq;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands;
using Okapia.Domain.Commands.User;
using Okapia.Domain.Contracts;
using Okapia.Domain.ViewModels;

namespace Okapia.Application.Applications
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IUserRepository _userRepository;
        private readonly IUserApplication _userApplication;
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AccountApplication(IUserRepository userRepository, IAccountRepository accountRepository,
            IAuthHelper authHelper, IPasswordHasher passwordHasher, IUserApplication userApplication)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _authHelper = authHelper;
            _passwordHasher = passwordHasher;
            _userApplication = userApplication;
        }

        public OperationResult Login(Login login)
        {
            var result = new OperationResult("Account", "Login");
            var account = _accountRepository.Get(x => x.Username == login.Username, x => x.IsDeleted == false)
                .FirstOrDefault();
            if (account == null)
            {
                result.Message = ApplicationMessages.UserNotExists;
                return result;
            }

            var (verified, needsUpgrade) = _passwordHasher.Check(account.Password, login.Password);
            if (!verified)
            {
                result.Message = ApplicationMessages.IncorrectPassword;
                return result;
            }

            var userInfo = new AccountViewModel(account.Id, account.ReferenceRecordId, account.Username,
                account.Username,
                account.RoleId);
            _authHelper.Signin(userInfo);

            result.Message = ApplicationMessages.OperationSuccess;
            result.RecordId = account.RoleId;
            result.Success = true;
            return result;
        }

        public OperationResult Register(CreateUser command)
        {
            var operationResult = new OperationResult("RegisterUser", "Users");
            try
            {
                //if (_accountRepository.IsDuplicated(x => x.Username == command.NationalCardNumber))
                //{
                //    operationResult.Message = ApplicationMessages.DuplicatedUser;
                //    return operationResult;
                //}

                //var hashedPassword = _passwordHasher.Hash(command.PhoneNumber);

                //var account = new Account
                //{
                //    Username = command.NationalCardNumber,
                //    Password = hashedPassword,
                //    //ReferenceRecordId = user.UserId,
                //    RoleId = Constants.Roles.User.Id,
                //    IsDeleted = false
                //};

                //var user = new User
                //{
                //    UserFirstName = command.Name,
                //    UserLastName = command.Family,
                //    UserAddress = command.Address,
                //    UserEmail = command.Email,
                //    UserCityId = command.CityId,
                //    UserProvinceId = command.ProvinceId,
                //    UserBirthDate = DateTime.Now,
                //    UserNationalCode = command.NationalCardNumber,
                //    UserPhoneNumber = command.PhoneNumber,
                //    UserPostalCode = command.Postalcode,
                //    UserRegistrationDate = DateTime.Now,
                //    UserIsActivated = true,
                //    UserCustomerIntroductionLimit = 200,
                //    Account = account
                //};
                //_userRepository.Create(user);
                //_userRepository.SaveChanges();
                var result = _userApplication.Create(command);
                if (result.Success == false)
                    return result;
                //var userInfo = new AccountViewModel(account.Id, user.UserId, user.UserFirstName, account.Username,
                //    Constants.Roles.User.Id);
                //_authHelper.Signin(userInfo);
                operationResult.Success = true;
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

        public OperationResult Delete(long id)
        {
            var result = new OperationResult("Account", "Delete");
            try
            {
                var account = _accountRepository.GetAccount(id);
                if (account == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                account.IsDeleted = true;
                _accountRepository.Update(account);
                _accountRepository.SaveChanges();
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
            var result = new OperationResult("Account", "Delete");
            try
            {
                var account = _accountRepository.GetAccount(id);
                if (account == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                account.IsDeleted = false;
                _accountRepository.Update(account);
                _accountRepository.SaveChanges();
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

        public AccountViewModel GetAccountInfo()
        {
            return _authHelper.GetCurrnetUserInfo();
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var result = new OperationResult("Account", "ChangePassword");
            try
            {
                if (command.NewPassword != command.RepeatNewPassword)
                {
                    result.Message = ApplicationMessages.NotSamePassword;
                    return result;
                }

                var hashedPassword = _passwordHasher.Hash(command.NewPassword);
                var account = _accountRepository.GetAccount(command.AccountId);
                account.Password = hashedPassword;
                _accountRepository.Update(account);
                _accountRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
            }

            return result;
        }
    }
}