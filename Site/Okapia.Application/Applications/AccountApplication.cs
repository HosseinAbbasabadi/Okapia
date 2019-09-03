using System;
using System.Linq;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands;
using Okapia.Domain.Commands.User;
using Okapia.Domain.Contracts;
using Okapia.Domain.ViewModels;
using Okapia.EmailService;
using Okapia.SmsService;

namespace Okapia.Application.Applications
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IUserRepository _userRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IUserApplication _userApplication;
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ISmsService _smsService;
        private readonly IEmailService _emailService;
        private readonly ISettingApplication _settingApplication;

        public AccountApplication(IUserRepository userRepository, IAccountRepository accountRepository,
            IAuthHelper authHelper, IPasswordHasher passwordHasher, IUserApplication userApplication,
            ISmsService smsService, IJobRepository jobRepository, IEmailService emailService,
            ISettingApplication settingApplication)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _authHelper = authHelper;
            _passwordHasher = passwordHasher;
            _userApplication = userApplication;
            _smsService = smsService;
            _jobRepository = jobRepository;
            _emailService = emailService;
            _settingApplication = settingApplication;
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

        public OperationResult CreateVerificationCodeByMobile(string mobile)
        {
            var result = new OperationResult("Accounts", "CreateVerificationCode");
            try
            {
                long referenceRecordId;
                var user = _userRepository.Get(x => x.UserPhoneNumber == mobile).FirstOrDefault();
                if (user == null)
                {
                    var job = _jobRepository.Get(x => x.JobMobile1 == mobile || x.JobMobile2 == mobile)
                        .FirstOrDefault();
                    if (job == null)
                    {
                        result.Message = ApplicationMessages.UserMobileNotExists;
                        return result;
                    }

                    referenceRecordId = job.JobId;
                }
                else
                {
                    referenceRecordId = user.UserId;
                }

                var random = new Random();
                var code = random.Next(10000, 99999);
                var forgetPasswordMessage = $"{_settingApplication.GetForgetPasswordText()} {code}";
                _smsService.SendSms(forgetPasswordMessage, mobile);
                var account = _accountRepository.GetAccountByReferenceRecord(referenceRecordId);
                account.RefereshToken = code;
                _accountRepository.SaveChanges();
                result.Message = ApplicationMessages.VerificationCodeSent;
                result.RecordId = code;
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

        public OperationResult CreateVerificationCodeByEmail(string email)
        {
            var result = new OperationResult("Accounts", "CreateVerificationCode");
            try
            {
                long referenceRecordId;
                var user = _userRepository.Get(x => x.UserEmail == email).FirstOrDefault();
                if (user == null)
                {
                    var job = _jobRepository.Get(x => x.JobEmailAddress == email)
                        .FirstOrDefault();
                    if (job == null)
                    {
                        result.Message = ApplicationMessages.UserEmailNotExists;
                        return result;
                    }

                    referenceRecordId = job.JobId;
                }
                else
                {
                    referenceRecordId = user.UserId;
                }

                var random = new Random();
                var code = random.Next(10000, 99999);
                _emailService.SendEmail("کد احراز هویت اُکاپیا", $"کد احراز هویت شما: {code}", email);
                var account = _accountRepository.GetAccountByReferenceRecord(referenceRecordId);
                account.RefereshToken = code;
                _accountRepository.SaveChanges();
                result.Message = ApplicationMessages.VerificationCodeSent;
                result.RecordId = code;
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

        public OperationResult VerifyWithSms(string mobile, long code)
        {
            var result = new OperationResult("Accounts", "VerifyWithSms");
            try
            {
                long referenceRecordId;
                var user = _userRepository.Get(x => x.UserPhoneNumber == mobile).FirstOrDefault();
                if (user == null)
                {
                    var job = _jobRepository.Get(x => x.JobMobile1 == mobile || x.JobMobile2 == mobile)
                        .FirstOrDefault();
                    if (job == null)
                    {
                        result.Message = ApplicationMessages.UserMobileNotExists;
                        return result;
                    }

                    referenceRecordId = job.JobId;
                }
                else
                {
                    referenceRecordId = user.UserId;
                }

                var account = _accountRepository.GetAccountByReferenceRecord(referenceRecordId);
                if (account.RefereshToken != code)
                {
                    result.Message = ApplicationMessages.WrongVerificationCode;
                    return result;
                }

                account.RefereshToken = 0;
                _accountRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.RecordId = account.Id;
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

        public OperationResult VerifyWithEmail(string email, long code)
        {
            var result = new OperationResult("Accounts", "VerifyWithEmail");
            try
            {
                long referenceRecordId;
                var user = _userRepository.Get(x => x.UserEmail == email).FirstOrDefault();
                if (user == null)
                {
                    var job = _jobRepository.Get(x => x.JobMobile1 == email || x.JobMobile2 == email)
                        .FirstOrDefault();
                    if (job == null)
                    {
                        result.Message = ApplicationMessages.UserMobileNotExists;
                        return result;
                    }

                    referenceRecordId = job.JobId;
                }
                else
                {
                    referenceRecordId = user.UserId;
                }

                var account = _accountRepository.GetAccountByReferenceRecord(referenceRecordId);
                if (account.RefereshToken != code)
                {
                    result.Message = ApplicationMessages.WrongVerificationCode;
                    return result;
                }

                account.RefereshToken = 0;
                _accountRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.RecordId = account.Id;
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
    }
}