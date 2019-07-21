using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthHelper _authHelper;
        private readonly ICityApplication _cityApplication;
        private readonly IDistrictApplication _districtApplication;
        private readonly INeighborhoodApplication _neighborhoodApplication;
        private readonly IPasswordHasher _passwordHasher;

        public JobApplication(IJobRepository jobRepository, IAccountRepository accountRepository,
            IAuthHelper authHelper, ICityApplication cityApplication, IDistrictApplication districtApplication,
            INeighborhoodApplication neighborhoodApplication, IPasswordHasher passwordHasher)
        {
            _jobRepository = jobRepository;
            _accountRepository = accountRepository;
            _authHelper = authHelper;
            _cityApplication = cityApplication;
            _districtApplication = districtApplication;
            _neighborhoodApplication = neighborhoodApplication;
            _passwordHasher = passwordHasher;
        }

        public OperationResult Create(CreateJob command)
        {
            var result = new OperationResult("Jobs", "Create");
            try
            {
                if (_jobRepository.Exists(x => x.JobSlug == command.JobSlug))
                {
                    result.Message = ApplicationMessages.DuplicatedSlug;
                    return result;
                }

                if (_jobRepository.Exists(x => x.JobName == command.JobName,
                    x => x.JobCategory == command.JobCategoryId, x => x.JobProvienceId == command.JobProvienceId,
                    x => x.JobCityId == command.JobCityId, x => x.JobDistrictId == command.JobDistrictId))
                {
                    result.Message = ApplicationMessages.DuplicatedRecord;
                    return result;
                }

                if (_accountRepository.Exists(x => x.Username == command.Username,
                    x => x.RoleId == Constants.Roles.Job.Id))
                {
                    result.Message = ApplicationMessages.DuplicatedJob;
                    return result;
                }

                if (string.IsNullOrEmpty(command.Photos.First().Name))
                {
                    result.Message = ApplicationMessages.PictureIsRequired;
                    return result;
                }

                var jobWithoutPictures = MapCreateJobToJob(command);
                var job = MapJobPictures(command.Photos, jobWithoutPictures);
                var hashedPassword = _passwordHasher.Hash(command.Password);
                var account = new Account
                {
                    Username = command.Username.ToLower(),
                    Password = hashedPassword,
                    IsDeleted = false,
                    RoleId = Constants.Roles.Job.Id,
                    //ReferenceRecordId = job.JobId
                };
                job.Account = account;
                _jobRepository.Create(job);
                _jobRepository.SaveChanges();
                //var account = new Account
                //{
                //    Username = command.Username.ToLower(),
                //    Password = hashedPassword,
                //    IsDeleted = false,
                //    RoleId = Constants.Roles.Job.Id,
                //    ReferenceRecordId = job.JobId
                //};
                //_accountRepository.Create(account);
                //_accountRepository.SaveChanges();
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

        public OperationResult Delete(int id, string redirect301Url)
        {
            var result = new OperationResult("Jobs", "Delete");
            try
            {
                if (!Uri.IsWellFormedUriString(redirect301Url, UriKind.Absolute))
                {
                    result.Message = ApplicationMessages.WrongUrlFormat;
                    return result;
                }

                var job = _jobRepository.GetJobIncludingAccount(id);
                job.Account.IsDeleted = true;
                job.JobRemoved301InsteadUrl = redirect301Url;
                _jobRepository.Attach(job);
                _jobRepository.SaveChanges();
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

        public void Activate(int id)
        {
            try
            {
                var job = _jobRepository.GetJobIncludingAccount(id);
                job.Account.IsDeleted = false;
                job.JobRemoved301InsteadUrl = null;
                _jobRepository.Attach(job);
                _jobRepository.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public OperationResult Update(int id, EditJob command)
        {
            var result = new OperationResult("Jobs", "Update");
            try
            {
                if (string.IsNullOrEmpty(command.Photos.First().Name))
                {
                    result.Message = ApplicationMessages.PictureIsRequired;
                    return result;
                }

                var checkingJob = _jobRepository.GetJob(id);
                if (checkingJob == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var jobWithoutPictures = MapEditJobToJob(command);
                var job = MapJobPicturesForUpdate(command.Photos, jobWithoutPictures);
                var authInfo = _accountRepository.GetAccountByReferenceRecord(job.JobId, Constants.Roles.Job.Id);
                authInfo.Username = command.Username.ToLower();
                authInfo.IsDeleted = command.IsDeleted;
                _jobRepository.Update(job);
                _accountRepository.Update(authInfo);
                _jobRepository.SaveChanges();
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

        public EditJob GetJobDetails(int id)
        {
            var jobDetails = _jobRepository.GetJobDetails(id);
            jobDetails.Citeies =
                new SelectList(_cityApplication.GetCitiesBy(jobDetails.JobProvienceId), "Id", "Name");
            jobDetails.Districts =
                new SelectList(_districtApplication.GetDistrictsBy(jobDetails.JobCityId), "Id", "Name");
            jobDetails.Neighborhoods =
                new SelectList(_neighborhoodApplication.GetNeighborhoodsBy(jobDetails.JobDistrictId), "Id", "Name");
            return jobDetails;
        }

        private Job MapCreateJobToJob(CreateJob command)
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
                JobSlug = command.JobSlug.GenerateSlug(),
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
                JobBefitPercentForIntroducingEndCustomer = command.JobBefitPercentForIntroducingEndCustomer,
                MarketerPercentForRegisteringShop = command.MarketerPercentForRegisteringShop,
                MarketerId = command.MarketerId,
                JobPosNameNumber = command.JobPosNameNumber,
                JobAccountNumber = command.JobAccountNumber,
                JobShowOrderIncategory = command.JobShowOrderIncategory,
                ShowInHomePage = command.ShowInHomePage,
                RegisteringEmployerId = _authHelper.GetCurrnetUserInfo().AuthUserId,
                CustomerIntroductionLimit = command.CustomerIntroductionLimit,
                IsWebsite = command.IsWebsite,
                WebSiteUrl = command.WebsiteUrl,
                InstagramUrl = command.InstagramUrl,
                TelegramUrl = command.TelegramUrl
            };
            return job;
        }

        private Job MapEditJobToJob(EditJob command)
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
                JobSlug = command.JobSlug.GenerateSlug(),
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
                JobBefitPercentForIntroducingEndCustomer = command.JobBefitPercentForIntroducingEndCustomer,
                MarketerPercentForRegisteringShop = command.MarketerPercentForRegisteringShop,
                MarketerId = command.MarketerId,
                JobPosNameNumber = command.JobPosNameNumber,
                JobAccountNumber = command.JobAccountNumber,
                JobShowOrderIncategory = command.JobShowOrderIncategory,
                ShowInHomePage = command.ShowInHomePage,
                RegisteringEmployerId = _authHelper.GetCurrnetUserInfo().AuthUserId,
                CustomerIntroductionLimit = command.CustomerIntroductionLimit,
                IsWebsite = command.IsWebsite,
                WebSiteUrl = command.WebsiteUrl,
                InstagramUrl = command.InstagramUrl,
                TelegramUrl = command.TelegramUrl,
                JobId = command.JobId,
                JobRemoved301InsteadUrl = command.RedirectInstead301Url
            };
            return job;
        }

        private static Job MapJobPictures(IReadOnlyCollection<JobPictureViewModel> jobPictureViewModels, Job job)
        {
            var jobPictures = new List<JobPicture>();
            foreach (var jobPictureViewModel in jobPictureViewModels)
            {
                var jobPicture = new JobPicture
                {
                    JobPictureTitle = jobPictureViewModel.Title,
                    JobPictureSmallDescription = jobPictureViewModel.Description,
                    Job = job,
                    JobPictureName = jobPictureViewModel.Name,
                    JobPicturThumbUrl = jobPictureViewModel.Name,
                    JobPictureAlt = jobPictureViewModel.Description
                };
                if (jobPictureViewModel == jobPictureViewModels.First())
                    jobPicture.IsDefault = true;
                jobPictures.Add(jobPicture);
            }

            job.JobPictures = jobPictures;
            return job;
        }

        private Job MapJobPicturesForUpdate(IEnumerable<JobPictureViewModel> pictures, Job job)
        {
            var jobPictures = pictures.Select(picture =>
                {
                    var jobPicture = new JobPicture
                    {
                        JobPictureId = picture.Id,
                        JobPictureTitle = picture.Title,
                        JobPictureSmallDescription = picture.Description,
                        JobPictureName = picture.Name,
                        JobPicturThumbUrl = picture.Name,
                        JobPictureAlt = picture.Alt,
                        Job = job,
                        IsDefault = false
                    };
                    return jobPicture;
                })
                .ToList();

            jobPictures.First().IsDefault = true;

            job.JobPictures = jobPictures;
            return job;
        }

        public List<JobViewModel> GetJobsForList(JobSearchModel searchModel, out int recordCount)
        {
            return _jobRepository.Search(searchModel, out recordCount);
        }

        public OperationResult CheckJobSlugDuplication(string slug)
        {
            var result = new OperationResult("Jobs", "CheckJobSlugDuplication");
            try
            {
                var slugified = slug.GenerateSlug();
                if (_jobRepository.Exists(x => x.JobSlug == slugified))
                {
                    result.Message = ApplicationMessages.DuplicatedSlug;
                    return result;
                }

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