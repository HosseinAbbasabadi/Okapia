﻿using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Job;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
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
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJobRequestRepository _jobRequestRepository;
        private readonly IMarketerApplication _marketerApplication;
        private readonly ICategoryApplication _categoryApplication;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly INeighborhoodRepository _neighborhoodRepository;
        private readonly IJobQuery _jobQuery;
        private readonly ICityApplication _cityApplication;
        private readonly IDistrictApplication _districtApplication;
        private readonly INeighborhoodApplication _neighborhoodApplication;
        private readonly IBoxRepository _boxRepository;

        public JobApplication(IJobRepository jobRepository, IAccountRepository accountRepository,
            IAuthHelper authHelper, IPasswordHasher passwordHasher, IJobRequestRepository jobRequestRepository,
            IMarketerApplication marketerApplication,
            ICategoryApplication categoryApplication, ICityRepository cityRepository,
            IDistrictRepository districtRepository, INeighborhoodRepository neighborhoodRepository, IJobQuery jobQuery,
            ICityApplication cityApplication, IDistrictApplication districtApplication,
            INeighborhoodApplication neighborhoodApplication, IBoxRepository boxRepository)
        {
            _jobRepository = jobRepository;
            _accountRepository = accountRepository;
            _authHelper = authHelper;
            _passwordHasher = passwordHasher;
            _jobRequestRepository = jobRequestRepository;
            _marketerApplication = marketerApplication;
            _categoryApplication = categoryApplication;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _neighborhoodRepository = neighborhoodRepository;
            _jobQuery = jobQuery;
            _cityApplication = cityApplication;
            _districtApplication = districtApplication;
            _neighborhoodApplication = neighborhoodApplication;
            _boxRepository = boxRepository;
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

                if (command.JobRequestId != 0)
                {
                    var jobRequest = _jobRequestRepository.GetJobRequest(command.JobRequestId);
                    jobRequest.Status = Constants.Statuses.Registered.Id;
                    jobRequest.LastModificationDate = DateTime.Now;
                    jobRequest.LastModificationEmployeeId = _authHelper.GetCurrnetUserInfo().AuthUserId;
                    //_jobRequestRepository.Update(jobRequest);
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
                };
                job.Account = account;
                _jobRepository.Create(job);
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

        public OperationResult Update(EditJob command)
        {
            var result = new OperationResult("Jobs", "Update");
            try
            {
                if (string.IsNullOrEmpty(command.Photos.First().Name))
                {
                    result.Message = ApplicationMessages.PictureIsRequired;
                    return result;
                }

                if (!_jobRepository.Exists(x => x.JobId == command.JobId))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var jobWithoutPictures = MapEditJobToJob(command);
                var job = MapJobPicturesForUpdate(command.Photos, jobWithoutPictures);
                var account = _accountRepository.GetAccountByReferenceRecord(job.JobId);
                account.Username = command.Username.ToLower();
                account.IsDeleted = command.IsDeleted;
                _jobRepository.Update(job);
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
                new SelectList(_cityRepository.Get(x => x.ProvinceId == jobDetails.JobProvienceId), "Id", "Name");
            jobDetails.Districts =
                new SelectList(_districtRepository.Get(x => x.CityId == jobDetails.JobCityId), "Id", "Name");
            jobDetails.Neighborhoods =
                new SelectList(_neighborhoodRepository.Get(x => x.DistrictId == jobDetails.JobDistrictId), "Id",
                    "Name");
            jobDetails.Marketers =
                new SelectList(_marketerApplication.GetMarketers(), "MarketerId", "MarketerFullName");
            jobDetails.Categories =
                new SelectList(_categoryApplication.GetParentCategories(), "CategoryId", "CategoryName");
            return jobDetails;
        }

        private Job MapCreateJobToJob(CreateJob command)
        {
            var job = new Job
            {
                JobName = command.JobName,
                JobSmallDescription = command.JobSmallDescription,
                JobFeatures = command.JobFeatures,
                JobUsageCondition = command.JobUsageCondition,
                JobDescription = command.Content,
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
                JobPrice = command.JobPrice,
                JobDiscountPrice = command.JobDiscountPrice
            };
            return job;
        }

        private Job MapEditJobToJob(EditJob command)
        {
            var job = new Job
            {
                JobName = command.JobName,
                JobSmallDescription = command.JobSmallDescription,
                JobFeatures = command.JobFeatures,
                JobUsageCondition = command.JobUsageCondition,
                JobDescription = command.Content,
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
                JobRemoved301InsteadUrl = command.RedirectInstead301Url,
                JobPrice = command.JobPrice,
                JobDiscountPrice = command.JobDiscountPrice
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

        public OperationResult AddJobToBox(AddToBox command)
        {
            var result = new OperationResult("Jobs", "AddJobToBox");
            try
            {
                if (!_boxRepository.Exists(x => x.BoxId == command.BoxId))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var job = _jobRepository.Get(command.JobId);
                if (job == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var boxJob = new BoxJob
                {
                    JobId = command.JobId,
                    BoxId = command.BoxId
                };

                job.BoxJobs.Add(boxJob);
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

        public List<JobViewModel> GetActiveJobs()
        {
            return _jobRepository.GetActiveJobs();
        }

        public List<JobSearchResultViewModel> Search(string phrase, string province)
        {
            return _jobQuery.Search(phrase, province);
        }

        public List<JobItemViewModel> SearchResult(string phrase, string province)
        {
            return _jobQuery.SearchResult(phrase, province);
        }

        public JobViewDetailsViewModel GetJobViewDetails(string slug)
        {
            return _jobQuery.GetJobViewDetails(slug);
        }

        public List<JobItemViewModel> GetJobsByCategoryId(int categoryId)
        {
            return _jobQuery.GetJobsByCatgoryId(categoryId);
        }

        public List<JobItemViewModel> GetJobsForCategoryView(JobViewSearchModel searchModel)
        {
            if (searchModel.Province != 0)
                searchModel.Cities = new SelectList(_cityApplication.GetCitiesBy(searchModel.Province), "Id", "Name");
            if (searchModel.City != 0)
                searchModel.Districts =
                    new SelectList(_districtApplication.GetDistrictsBy(searchModel.City), "Id", "Name");
            if (searchModel.Neighborhood != 0)
                searchModel.Neighborhoods =
                    new SelectList(_neighborhoodApplication.GetNeighborhoodsBy(searchModel.District), "Id", "Name");
            return _jobQuery.GetJobsForCategoryView(searchModel);
        }

        public long GetActiveJobsCount()
        {
            return _jobQuery.GetActiveJobsCount();
        }
    }
}