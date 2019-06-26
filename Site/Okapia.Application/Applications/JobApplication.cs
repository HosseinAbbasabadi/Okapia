using System;
using Okapia.Application.Contracts;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Application.Applications
{
    public class JobApplication : IJobApplication
    {
        private readonly IJobRepository _jobRepository;

        public JobApplication(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public void Create(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
