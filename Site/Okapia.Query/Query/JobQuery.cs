using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Comment;
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
                    JobFeatures = job.JobFeatures
                };

            var jobDetails = query.FirstOrDefault();
            jobDetails.JobFeatureList = jobDetails.JobFeatures.Split(',').ToList();
            var jobPictures = _jobPictureRepository.GetJobPicturesByJob(jobDetails.JobId).Select(x =>
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
                    CommentTitle = c.CommentTitle,
                    CommentText = c.CommnetText,
                    CommentCreationDate = c.CommentCreationDate.ToFarsi(),
                    CommentAgreeCount = c.CommentAgreeCount,
                    CommentDisagreeCount = c.CommentDisagreeCount
                };
                commentItemViewModels.Add(comment);
            });

            jobDetails.Comments = commentItemViewModels;
            jobDetails.Photos = jobPictures;
            return jobDetails;
        }

        public List<JobStaredViewModel> GetStaredJobs()
        {
            return _context.Jobs.OrderByDescending(x => x.JobId).Include(x => x.JobPictures).Include(x => x.Account)
                .Where(x => x.IsStared && !x.Account.IsDeleted)
                .Select(job =>
                    new JobStaredViewModel
                    {
                        JobId = job.JobId,
                        JobSlug = job.JobSlug,
                        JobName = job.JobName,
                        JobSmallDescription = job.JobSmallDescription,
                        JobPictureName = job.JobPictures.First(x => x.IsDefault).JobPictureName,
                        JobPictureAlt = job.JobPictures.First(x => x.IsDefault).JobPictureAlt,
                        JobPictureTitle = job.JobPictures.First(x => x.IsDefault).JobPictureTitle
                    }).ToList();
        }

        public List<JobItemViewModel> GetJobsForCategoryView(JobViewSearchModel searchModel)
        {
            var q = _context.Jobs.Include(x => x.Account).Include(x => x.JobPictures)
                .Where(x => x.Account.IsDeleted == false);

            if (!string.IsNullOrEmpty(searchModel.Text))
            {
                q = q.Where(x =>
                    x.JobName.Contains(searchModel.Text) || x.JobSmallDescription.Contains(searchModel.Text) ||
                    x.JobDescription.Contains(searchModel.Text) || x.JobFeatures.Contains(searchModel.Text) ||
                    x.JobMetaDesccription.Contains(searchModel.Text) || x.JobMetaTag.Contains(searchModel.Text));
            }

            if ((searchModel.CategoryId != 0))
                q = q.Where(x => x.JobCategory == searchModel.CategoryId);
            if (searchModel.Province != 0)
                q = q.Where(x => x.JobProvienceId == searchModel.Province);
            if (searchModel.City != 0)
                q = q.Where(x => x.JobCityId == searchModel.City);
            if (searchModel.District != 0)
                q = q.Where(x => x.JobDistrictId == searchModel.District);
            if (searchModel.Neighborhood != 0)
                q = q.Where(x => x.JobNeighborhoodId == searchModel.Neighborhood);

            var query = from job in q
                join city in _context.Cities
                    on job.JobCityId equals city.Id
                select new JobItemViewModel
                {
                    JobId = job.JobId,
                    JobSlug = job.JobSlug,
                    JobName = job.JobName,
                    JobPicture = job.JobPictures.First(x => x.IsDefault).JobPictureName,
                    JobPictureAlt = job.JobPictures.First(x => x.IsDefault).JobPictureAlt,
                    City = city.Name,
                    BenefitPercentForEndCustomer = job.JobBenefitPercentForEndCustomer
                };

            return query.ToList();
        }

        public long GetActiveJobsCount()
        {
            return _context.Jobs.Count();
        }
    }
}