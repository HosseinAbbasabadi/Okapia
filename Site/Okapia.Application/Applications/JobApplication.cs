using System;
using System.Collections.Generic;
using System.Linq;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Job;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;
using Okapia.Domain.ViewModels.JobPicture;

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
            try
            {
                if (string.IsNullOrEmpty(command.Photos.First())) return;
                var jobWithoutPictures = MapCreateJobToJob(command, command.Photos);
                var job = MapJobPictures(command.Photos, command.JobName, command.JobSmallDescription, "",
                    jobWithoutPictures);
                _jobRepository.Create(job);
                _jobRepository.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void Delete(int id, string redirect301Url)
        {
            try
            {
                var job = _jobRepository.Get(x => x.JobId == id).First();
                job.IsDeleted = true;
                job.JobRemoved301InsteadUrl = redirect301Url;
                _jobRepository.Update(job);
                _jobRepository.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void Activate(int id)
        {
            try
            {
                var job = _jobRepository.Get(x => x.JobId == id).First();
                job.IsDeleted = false;
                job.JobRemoved301InsteadUrl = null;
                _jobRepository.Update(job);
                _jobRepository.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void Update(int id, EditJob command)
        {
            try
            {
                var checkingJob = _jobRepository.GetJob(id);
                if (checkingJob == null) return;
                if (string.IsNullOrEmpty(command.Photos.First().Name)) return;
                var jobWithoutPictures = MapEditJobToJob(command, command.Photos);
                var job = MapJobPicturesForUpdate(command.Photos, command.JobName, command.JobSmallDescription, "",
                    jobWithoutPictures);
                _jobRepository.Update(job);
                _jobRepository.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public EditJob GetJobDetails(int id)
        {
            try
            {
                return _jobRepository.GetJobDetails(id);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private static Job MapCreateJobToJob(CreateJob command, IEnumerable<string> photoNames)
        {
            var job = new Job
            {
                JobName = command.JobName,
                JobSmallDescription = command.JobSmallDescription,
                JobDescription = command.JobDescription,
                JobContactTitile = command.JobContactTitile,
                JobManagerFirstName = command.JobManagerFirstName,
                JobManagerLastName = command.JobManagerLastName,
                JobEmailAddress = command.JobEmailAddress,
                JobCategory = command.JobCategoryId,
                JobTel1 = command.JobTel1,
                JobTel2 = command.JobTel2,
                JobMobile1 = command.JobMobile1,
                JobMobile2 = command.JobMobile2,
                JobProvienceId = command.JobProvienceId,
                JobCityId = command.JobCityId,
                JobDistrictId = command.JobDistrictId,
                JobNeighborhoodId = command.JobneighborhoodId,
                JobAddress = command.JobAddress,
                JobWazeMap = command.JobWazeMap,
                JobWazeLink = command.JobWazeLink,
                JobPageTittle = command.JobPageTittle,
                JobSlug = Slugify.GenerateSlug(command.JobSlug),
                JobMetaTag = command.JobMetaTag,
                JobMetaDesccription = command.JobMetaDesccription,
                JobSeohead = command.JobSeohead,
                JobCanonicalAddress = command.JobCanonicalAddress,
                JobContractNumber = command.JobContractNumber,
                JobBenefitPercentForCompany = command.JobBenefitPercentForCompany,
                JobBenefitPercentForEndCustomer = command.JobBenefitPercentForEndCustomer,
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

        private static Job MapEditJobToJob(EditJob command, IEnumerable<JobPictureViewModel> photos)
        {
            var job = new Job
            {
                JobName = command.JobName,
                JobSmallDescription = command.JobSmallDescription,
                JobDescription = command.JobDescription,
                JobContactTitile = command.JobContactTitile,
                JobManagerFirstName = command.JobManagerFirstName,
                JobManagerLastName = command.JobManagerLastName,
                JobEmailAddress = command.JobEmailAddress,
                JobCategory = command.JobCategoryId,
                JobTel1 = command.JobTel1,
                JobTel2 = command.JobTel2,
                JobMobile1 = command.JobMobile1,
                JobMobile2 = command.JobMobile2,
                JobProvienceId = command.JobProvienceId,
                JobCityId = command.JobCityId,
                JobDistrictId = command.JobDistrictId,
                JobNeighborhoodId = command.JobneighborhoodId,
                JobAddress = command.JobAddress,
                JobWazeMap = command.JobWazeMap,
                JobWazeLink = command.JobWazeLink,
                JobPageTittle = command.JobPageTittle,
                JobSlug = Slugify.GenerateSlug(command.JobSlug),
                JobMetaTag = command.JobMetaTag,
                JobMetaDesccription = command.JobMetaDesccription,
                JobSeohead = command.JobSeohead,
                JobCanonicalAddress = command.JobCanonicalAddress,
                JobContractNumber = command.JobContractNumber,
                JobBenefitPercentForCompany = command.JobBenefitPercentForCompany,
                JobBenefitPercentForEndCustomer = command.JobBenefitPercentForEndCustomer,
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
                RegisteringEmployerId = 1, //currentUser
                CustomerIntroductionLimit = command.CustomerIntroductionLimit,
                IsWebsite = command.IsWebsite,
                WebSiteUrl = command.WebsiteUrl,
                InstagramUrl = command.InstagramUrl,
                TelegramUrl = command.TelegramUrl,
                JobId = command.JobId,
                IsDeleted = command.IsDeleted,
                JobRemoved301InsteadUrl = command.RedirectInstead301Url
            };
            return job;
        }

        private static Job MapJobPictures(IReadOnlyCollection<string> pictureUris, string title,
            string description, string thumbUri, Job job)
        {
            var jobPictures = new List<JobPicture>();
            foreach (var pictureUri in pictureUris)
            {
                var jobPicture = new JobPicture
                {
                    JobPictureTitle = title,
                    JobPictureSmallDescription = description,
                    Job = job,
                    JobPictureUrl = pictureUri,
                    JobPicturThumbUrl = thumbUri,
                    JobPictureAlt = description
                };
                if (pictureUri == pictureUris.First())
                    jobPicture.IsDefault = true;
                jobPictures.Add(jobPicture);
            }

            job.JobPictures = jobPictures;
            return job;
        }

        private static Job MapJobPicturesForUpdate(IReadOnlyCollection<JobPictureViewModel> pictures, string title,
            string description, string thumbUri, Job job)
        {
            var jobPictures = new List<JobPicture>();
            foreach (var picture in pictures)
            {
                var jobPicture = new JobPicture
                {
                    JobPictureId = picture.Id,
                    JobPictureTitle = title,
                    JobPictureSmallDescription = description,
                    Job = job,
                    JobPictureUrl = picture.Name,
                    JobPicturThumbUrl = thumbUri,
                    JobPictureAlt = description
                };
                if (picture.Name == pictures.First().Name)
                    jobPicture.IsDefault = true;
                jobPictures.Add(jobPicture);
            }

            job.JobPictures = jobPictures;
            return job;
        }

        public List<JobViewModel> GetJobsForList(JobSearchModel searchModel, out int recordCount)
        {
            return _jobRepository.Search(searchModel, out recordCount);
        }
    }
}