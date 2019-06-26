using System;
using Okapia.Application.Commands.Job;
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

        public void Create(CreateJob command)
        {
            var id = (int) _jobRepository.GetNextId("JobSeq");
            var job = MapCreateJobToJob(command, id);
            _jobRepository.Create(job);
        }

        private static Job MapCreateJobToJob(CreateJob command, int id)
        {
            var job = new Job
            {
                JobId = id,
                JobName = command.JobName,
                JobSmallDescription = command.JobSmallDescription,
                JobDescription = command.JobDescription,
                JobContactTitile = command.JobContactTitile,
                JobManagerFirstName = command.JobManagerFirstName,
                JobManagerLastName = command.JobManagerLastName,
                JobEmailAddress = command.JobEmailAddress,
                //JobCategory = command.
                JobTel1 = command.JobTel1,
                JobTel2 = command.JobTel2,
                JobMobile1 = command.JobMobile1,
                JobMobile2 = command.JobMobile2,
                //JobGeoLocation = command.ge
                JobProvienceId = command.JobProvienceId,
                JobCityId = command.JobCityId,
                JobAddress = command.JobAddress,
                JobMap = command.JobMap,
                JobPageTittle = command.JobPageTittle,
                JobSlug = command.JobSlug,
                JobMetaTag = command.JobMetaTag,
                JobMetaDesccription = command.JobMetaDesccription,
                JobSeohead = command.JobSeohead,
                JobCanonicalAddress = command.JobCanonicalAddress,
                JobContractNumber = command.JobContractNumber,
                JobBenefitPercentForCompany = command.JobBenefitPercentForCompany,
                JobBenefitPercentForEndCustomer = command.JobBenefitPercentForEndCustomer,
                JobRemoved301InsteadUrl = command.JobRemoved301InsteadUrl,
                JobDiscountPercentForCustomer = command.JobDiscountPercentForCustomer,
                //JobDiscountPercentForCompnay = command.disc,
                //JobDiscountPercentForSabaMehrDiscount = 
                //JobBefitPercentForIntroducingEndCustomer = command.benefitfor
                MarketerPercentForRegisteringShop = command.MarketerPercentForRegisteringShop,
                MarketerId = command.MarketerId,
                JobPosNameNumber = command.JobPosNameNumber,
                JobAccountNumber = command.JobAccountNumber,
                JobShowOrderIncategory = command.JobShowOrderIncategory,
                ShowInHomePage = command.ShowInHomePage,
                IsDeleted = false,
                RegisteringEmployerId = 1, //currentUser
                CustomerIntroductionLimit = command.CustomerIntroductionLimit,
                IsWebsite = command.IsWebsite,
                WebSiteUrl = command.WebsiteUrl,
                InstagramUrl = command.InstagramUrl,
                TelegramUrl = command.TelegramUrl
            };
            return job;
        }
    }
}