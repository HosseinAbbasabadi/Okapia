using System;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands;
using Okapia.Domain.Contracts;

namespace Okapia.Application.Applications
{
    public class AuthInfoApplication : IAuthInfoApplication
    {
        private readonly IAuthInfoRepository _authInfoRepository;

        public AuthInfoApplication(IAuthInfoRepository authInfoRepository)
        {
            _authInfoRepository = authInfoRepository;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var result = new OperationResult("AuthInfo", "ChangePassword");
            try
            {
                var authInfo = _authInfoRepository.GetAuthInfoByReferenceRecord(command.ReferenceRecordId, command.RoleId);
                authInfo.Password = command.NewPassword;
                _authInfoRepository.Update(authInfo);
                _authInfoRepository.SaveChanges();
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

        public ChangePassword GetChnagePasswordInfo(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
