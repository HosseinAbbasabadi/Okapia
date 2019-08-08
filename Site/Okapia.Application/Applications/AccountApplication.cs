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
    public class
        AccountApplication : IAccountApplication
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
                var result = _userApplication.Create(command);
                if (result.Success == false)
                    return result;
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
                if (!_accountRepository.Exists(x => x.Id == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var account = _accountRepository.GetAccount(id);

                account.IsDeleted = true;
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
                if (!_accountRepository.Exists(x => x.Id == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }
                var account = _accountRepository.GetAccount(id);

                account.IsDeleted = false;
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