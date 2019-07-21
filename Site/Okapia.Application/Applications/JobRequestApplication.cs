using System;
using System.Collections.Generic;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.RequestJob;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.RequestJob;

namespace Okapia.Application.Applications
{
    public class JobRequestApplication : IJobRequestApplication
    {
        private readonly IJobRequestRepository _jobRequestRepository;

        public JobRequestApplication(IJobRequestRepository jobRequestRepository)
        {
            _jobRequestRepository = jobRequestRepository;
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
                    Status = Statuses.Requested,
                    CreationDate = DateTime.Now
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

        public List<JobRequestViewModel> Search(JobRequestSearchModel searchModel, out int recordCount)
        {
            return _jobRequestRepository.Search(searchModel, out recordCount);
        }
    }
}