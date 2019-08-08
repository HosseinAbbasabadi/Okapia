using System;
using System.Collections.Generic;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.JobRequest;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.JobRequest;

namespace Okapia.Application.Applications
{
    public class JobRequestApplication : IJobRequestApplication
    {
        private readonly IJobRequestRepository _jobRequestRepository;
        private readonly IAuthHelper _authHelper;

        public JobRequestApplication(IJobRequestRepository jobRequestRepository, IAuthHelper authHelper)
        {
            _jobRequestRepository = jobRequestRepository;
            _authHelper = authHelper;
        }

        public OperationResult Create(CreateJobRequest command)
        {
            var result = new OperationResult("JobRequests", "Create");
            try
            {
                var jobRequest = new JobRequest
                {
                    Name = command.Name,
                    ContactTitle = command.ContactTitle,
                    ProvinceId = command.ProvinceId,
                    CityId = command.CityId,
                    Address = command.Address,
                    Description = command.Description,
                    Mobile = command.Mobile,
                    Tel = command.Tel,
                    Status = Constants.Statuses.Requested.Id,
                    CreationDate = DateTime.Now,
                    LastModificationDate = DateTime.Now
                };
                _jobRequestRepository.Create(jobRequest);
                _jobRequestRepository.SaveChanges();
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

        public OperationResult ChangeStatus(ChangeStatus command)
        {
            var result = new OperationResult("JobRequests", "ChangeStatus");
            try
            {
                var jobRequest = _jobRequestRepository.GetJobRequest(command.Id);
                jobRequest.Status = command.Status;
                jobRequest.LastModificationDate = DateTime.Now;
                jobRequest.LastModificationEmployeeId = _authHelper.GetCurrnetUserInfo().AuthUserId;
                _jobRequestRepository.SaveChanges();
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

        public JobRequestViewModel GetJobRequestDetails(long id)
        {
            return _jobRequestRepository.GetJobRequestDetails(id);
        }

        List<JobRequestViewModel> IJobRequestApplication.Search(JobRequestSearchModel searchModel, out int recordCount)
        {
            return Search(searchModel, out recordCount);
        }

        public List<JobRequestViewModel> Search(JobRequestSearchModel searchModel, out int recordCount)
        {
            return _jobRequestRepository.Search(searchModel, out recordCount);
        }

        public JobRequest GetJobRequest(long id)
        {
            return _jobRequestRepository.GetJobRequest(id);
        }
    }
}