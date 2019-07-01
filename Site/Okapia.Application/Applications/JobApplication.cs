using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Hosting;
using Okapia.Application.Commands.Job;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;
using System.Drawing;

namespace Okapia.Application.Applications
{
    public class JobApplication : IJobApplication
    {
        private readonly IJobRepository _jobRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private const int TenMegaBytes = 2 * 1024 * 1024;

        public JobApplication(IJobRepository jobRepository, IHostingEnvironment hostingEnvironment)
        {
            _jobRepository = jobRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public void Create(CreateJob command)
        {
            try
            {
                var photoNames = SaveJobPhotos(command).ToList();
                if (photoNames.Count == 0) return;
                var jobWithoutPictures = MapCreateJobToJob(command, photoNames);
                var job = MapJobPictures(photoNames, command.JobName, command.JobSmallDescription, "", jobWithoutPictures);
                _jobRepository.Create(job);
                _jobRepository.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private IEnumerable<string> SaveJobPhotos(CreateJob command)
        {
            var photoNames = new List<string>();
            var originalImageDistPath = Path.Combine(_hostingEnvironment.WebRootPath, "JobPhotos");
            //var thumbImageDistPath = Path.Combine(_hostingEnvironment.WebRootPath, "JobPhotos", "Thumbs");
            foreach (var photo in command.Photos)
            {
                if (photo == null) continue;
                if (!photo.FileName.IsValidFileName()) return null;
                if (photo.Length > TenMegaBytes) return null;
                var uniqueFileName = DateTime.Now.ToFileName() + "_" + photo.FileName;
                var filePath = Path.Combine(originalImageDistPath, uniqueFileName);
                var stream = new FileStream(filePath, FileMode.Create);
                photo.CopyTo(stream);
                photoNames.Add(uniqueFileName);
            }

            return photoNames;
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
                //JobGeoLocation = command.ge
                JobProvienceId = command.JobProvienceId,
                JobCityId = command.JobCityId,
                JobDistrictId = command.JobDistrictId,
                JobNeighborhoodId = command.JobneighborhoodId,
                JobAddress = command.JobAddress,
                JobMap = command.JobMap,
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

        private static Job MapJobPictures(IEnumerable<string> pictureUris, string title,
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