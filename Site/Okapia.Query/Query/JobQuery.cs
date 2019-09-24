using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Category;
using Okapia.Domain.ViewModels.Comment;
using Okapia.Domain.ViewModels.Faq;
using Okapia.Domain.ViewModels.Job;
using Okapia.Domain.ViewModels.JobPicture;

namespace Okapia.Query.Query
{
    public class JobQuery : BaseViewRepository<long, Job>, IJobQuery
    {
        private readonly IJobPictureRepository _jobPictureRepository;
        private readonly IAccountRepository _accountRepository;

        public JobQuery(OkapiaViewContext context, IJobPictureRepository jobPictureRepository,
            IAccountRepository accountRepository) : base(context)
        {
            _jobPictureRepository = jobPictureRepository;
            _accountRepository = accountRepository;
        }

        public List<JobSearchResultViewModel> Search(string text, string province)
        {
            var q = _context.Jobs.Include(x => x.Account).Include(x => x.JobPictures)
                .Where(x => x.Account.IsDeleted == false);

            if (!string.IsNullOrEmpty(text))
            {
                q = q.Where(x =>
                    x.JobName.Contains(text) || x.JobSmallDescription.Contains(text) ||
                    x.JobDescription.Contains(text) || x.JobFeatures.Contains(text) ||
                    x.JobMetaDesccription.Contains(text) || x.JobMetaTag.Contains(text));
            }

            var query = q.Join(_context.Provinces, job => job.JobProvienceId, pn => pn.Id, (job, pn) =>
                new JobSearchResultViewModel
                {
                    JobSlug = job.JobSlug,
                    JobPicture = job.JobPictures.FirstOrDefault().JobPictureName,
                    JobName = job.JobName,
                    Province = pn.Name
                });

            if (!string.IsNullOrEmpty(province))
            {
                query = query.Where(x => x.Province == province);
            }

            return query.ToList();
        }

        public List<JobItemViewModel> SearchResult(string text, string province)
        {
            var q = _context.Jobs.Include(x => x.Account).Include(x => x.JobPictures)
                .Where(x => x.Account.IsDeleted == false);

            if (!string.IsNullOrEmpty(text))
            {
                q = q.Where(x =>
                    x.JobName.Contains(text) || x.JobSmallDescription.Contains(text) ||
                    x.JobDescription.Contains(text) || x.JobFeatures.Contains(text) ||
                    x.JobMetaDesccription.Contains(text) || x.JobMetaTag.Contains(text));
            }

            var query = q.Join(_context.Provinces, job => job.JobProvienceId, pn => pn.Id, (job, pn) =>
                new JobItemViewModel
                {
                    JobSlug = job.JobSlug,
                    JobPicture = job.JobPictures.FirstOrDefault().JobPictureName,
                    JobName = job.JobName,
                    Province = pn.Name,
                    JobId = job.JobId,
                    BenefitPercentForEndCustomer = job.JobBenefitPercentForEndCustomer,
                    JobDiscountPrice = job.JobDiscountPrice,
                    JobPrice = job.JobPrice,
                    SmalDescription = job.JobSmallDescription,
                    JobPictureAlt = job.JobPictures.FirstOrDefault().JobPictureAlt,
                    JobPictureTitle = job.JobPictures.FirstOrDefault().JobPictureTitle
                });

            if (!string.IsNullOrEmpty(province))
            {
                query = query.Where(x => x.Province == province);
            }

            return query.ToList();
        }

        public JobViewDetailsViewModel GetJobViewDetails(string slug)
        {
            var query = from job in _context.Jobs
                join account in _context.Accounts
                    on job.JobId equals account.ReferenceRecordId
                join province in _context.Provinces
                    on job.JobProvienceId equals province.Id
                join city in _context.Cities
                    on job.JobCityId equals city.Id
                join district in _context.Districts
                    on job.JobDistrictId equals district.Id
                join neighborhood in _context.Neighborhoods
                    on job.JobNeighborhoodId equals neighborhood.Id
                where job.JobSlug == slug
                select new JobViewDetailsViewModel
                {
                    JobId = job.JobId,
                    JobName = job.JobName,
                    JobTel1 = job.JobTel1,
                    JobMobile1 = job.JobMobile1,
                    JobProvience = province.Name,
                    JobCity = city.Name,
                    JobDistrict = district.Name,
                    JobNeighborhood = neighborhood.Name,
                    JobAddress = job.JobAddress,
                    InstagramUrl = job.InstagramUrl,
                    TelegramUrl = job.TelegramUrl,
                    IsWebsite = job.IsWebsite,
                    JobBenefitPercentForEndCustomer = job.JobBenefitPercentForEndCustomer,
                    JobDescription = job.JobDescription,
                    JobMetaDesccription = job.JobMetaDesccription,
                    JobMetaTag = job.JobMetaTag,
                    JobMobile2 = job.JobMobile2,
                    JobTel2 = job.JobTel2,
                    JobPageTittle = job.JobPageTittle,
                    JobSeohead = job.JobSeohead,
                    JobSlug = job.JobSlug,
                    JobSmallDescription = job.JobSmallDescription,
                    JobWazeLink = job.JobWazeLink,
                    JobWazeMap = job.JobWazeMap,
                    WebsiteUrl = job.WebSiteUrl,
                    JobFeatures = job.JobFeatures,
                    JobUsageCondition = job.JobUsageCondition,
                    JobPrice = job.JobPrice,
                    JobDiscountPrice = job.JobDiscountPrice
                };

            var jobDetails = query.FirstOrDefault();
            if (!string.IsNullOrEmpty(jobDetails.JobFeatures))
                jobDetails.JobFeatureList = jobDetails.JobFeatures.Split(',').ToList();
            if (!string.IsNullOrEmpty(jobDetails.JobUsageCondition))
                jobDetails.JobUsageConditionList = jobDetails.JobUsageCondition.Split(',').ToList();
            var jobPictures = _jobPictureRepository.GetJobPicturesByJob(jobDetails.JobId)
                .Where(x => x.JobPictureName != null).Select(x =>
                    new JobPictureViewModel
                    {
                        Id = x.JobPictureId,
                        Name = x.JobPictureName,
                        Description = x.JobPictureSmallDescription,
                        Alt = x.JobPictureAlt,
                        Title = x.JobPictureTitle,
                        IsDefault = x.IsDefault
                    }).ToList();

            var commentItemViewModels = new List<CommentItemViewModel>();
            var comments = _context.Comments.Where(x =>
                    x.CommentIsConfirmed && !x.CommentIsDeleted && x.CommentOwner == "Job" &&
                    x.CommentOwnerRecordId == jobDetails.JobId)
                .ToList();
            comments.ForEach(c =>
            {
                //var commentator = _userRepository.GetUserBy(c.CommentatorAccountId);
                var commentator = _accountRepository.GetAccount(c.CommentatorAccountId);
                var comment = new CommentItemViewModel
                {
                    //CommentorFullname = commentator.UserFirstName + "" + commentator.UserLastName,
                    CommentorFullname = commentator.Username,
                    CommentText = c.CommnetText,
                    CommentCreationDate = c.CommentCreationDate.ToFarsi(),
                    CommentAgreeCount = c.CommentAgreeCount,
                    CommentDisagreeCount = c.CommentDisagreeCount
                };
                commentItemViewModels.Add(comment);
            });

            var faqs = _context.Faqs.Where(x => x.JobId == jobDetails.JobId).Select(faq => new FaqItemViewModel
            {
                Question = faq.Question,
                Answer = faq.Answer,
                Id = faq.Id
            }).ToList();

            jobDetails.Comments = commentItemViewModels;
            jobDetails.Photos = jobPictures;
            jobDetails.Faqs = faqs;
            return jobDetails;
        }

        public List<JobItemViewModel> GetJobsForCategoryView(JobViewSearchModel searchModel)
        {
            var q = _context.Jobs
                .Include(x => x.Account)
                .Include(x => x.JobPictures)
                .Where(x => x.Account.IsDeleted == false)
                .Join(_context.Provinces, job => job.JobProvienceId, province => province.Id,
                    (job, province) => new {job, province})
                .Join(_context.Cities, job => job.job.JobCityId, city => city.Id, (job, city) => new {job, city});

            if (!string.IsNullOrEmpty(searchModel.Text))
            {
                q = q.Where(x =>
                    x.job.job.JobName.Contains(searchModel.Text) ||
                    x.job.job.JobSmallDescription.Contains(searchModel.Text) ||
                    x.job.job.JobDescription.Contains(searchModel.Text) ||
                    x.job.job.JobFeatures.Contains(searchModel.Text) ||
                    x.job.job.JobMetaDesccription.Contains(searchModel.Text) ||
                    x.job.job.JobMetaTag.Contains(searchModel.Text));
            }

            if (searchModel.CategoryId != 0)
                q = q.Where(x => x.job.job.JobCategory == searchModel.CategoryId);
            if (searchModel.City != 0)
                q = q.Where(x => x.job.job.JobCityId == searchModel.City);
            if (searchModel.District != 0)
                q = q.Where(x => x.job.job.JobDistrictId == searchModel.District);
            if (searchModel.Neighborhood != 0)
                q = q.Where(x => x.job.job.JobNeighborhoodId == searchModel.Neighborhood);
            q = q.Where(x => x.job.province.Name == searchModel.Province);

            var query = q.Select(job => new JobItemViewModel
            {
                JobId = job.job.job.JobId,
                JobSlug = job.job.job.JobSlug,
                JobName = job.job.job.JobName,
                JobPicture = job.job.job.JobPictures.First(x => x.IsDefault).JobPictureName,
                JobPictureAlt = job.job.job.JobPictures.First(x => x.IsDefault).JobPictureAlt,
                City = job.city.Name,
                BenefitPercentForEndCustomer = job.job.job.JobBenefitPercentForEndCustomer,
                Province = job.job.province.Name
            });

            return query.ToList();
        }

        public List<JobItemViewModel> GetJobsByCatgoryId(int categoryId, string province)
        {
            var childrenCategories = _context.Categories.Where(x => x.CategoryParentId == categoryId)
                .Select(cat => new CategoryViewDetailsViewModel
                    {
                        CategoryId = cat.CategoryId,
                        CatgoryName = cat.CategoryName,
                    }
                ).ToList();
            var totalJobs = new List<JobItemViewModel>();
            totalJobs.AddRange(GetJobsByCategoryIdQuery(categoryId, province));
            foreach (var category in childrenCategories)
            {
                var jobs = GetJobsByCategoryIdQuery(category.CategoryId, province);
                totalJobs.AddRange(jobs);
            }

            return totalJobs;
        }

        private List<JobItemViewModel> GetJobsByCategoryIdQuery(int categoryId, string pn)
        {
            return _context.Jobs
                .Include(x => x.JobPictures)
                .Include(x => x.Account)
                .Where(x => x.JobCategory == categoryId && x.Account.IsDeleted == false)
                .Join(_context.Provinces, job=>job.JobProvienceId, province => province.Id, (job, province) => new {job , province})
                .Join(
                    _context.Cities, job => job.job.JobCityId, city => city.Id, (job, city) => new JobItemViewModel
                    {
                        JobName = job.job.JobName,
                        JobId = job.job.JobId,
                        JobSlug = job.job.JobSlug,
                        JobPicture = job.job.JobPictures.FirstOrDefault().JobPictureName,
                        JobPictureAlt = job.job.JobPictures.FirstOrDefault().JobPictureAlt,
                        JobPictureTitle = job.job.JobPictures.FirstOrDefault().JobPictureTitle,
                        JobPrice = job.job.JobPrice,
                        City = city.Name,
                        Province = job.province.Name,
                        BenefitPercentForEndCustomer = job.job.JobBenefitPercentForEndCustomer
                    })
                .Where(x=>x.Province == pn)
                .ToList();
        }

        public long GetActiveJobsCount()
        {
            return _context.Jobs.Count();
        }
    }
}