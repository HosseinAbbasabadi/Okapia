using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;
using Okapia.Domain.ViewModels.JobPicture;

namespace Okapia.Query.Query
{
    public class JobQuery : BaseViewRepository<long, Job>, IJobQuery
    {
        private readonly IJobPictureRepository _jobPictureRepository;

        public JobQuery(OkapiaViewContext context, IJobPictureRepository jobPictureRepository) : base(context)
        {
            _jobPictureRepository = jobPictureRepository;
        }

        public JobViewDetailsViewModel GetJobViewDetails(long id)
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
                where job.JobId == id
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
            var jobPictures = _jobPictureRepository.GetJobPicturesByJob(id).Select(x => new JobPictureViewModel
            {
                Id = x.JobPictureId,
                Name = x.JobPictureName,
                Description = x.JobPictureSmallDescription,
                Alt = x.JobPictureAlt,
                Title = x.JobPictureTitle,
                IsDefault = x.IsDefault
            }).ToList();

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
                        JobName = job.JobName,
                        JobSmallDescription = job.JobSmallDescription,
                        JobPictureName = job.JobPictures.First(x => x.IsDefault).JobPictureName,
                        JobPictureAlt = job.JobPictures.First(x => x.IsDefault).JobPictureAlt,
                    }).ToList();
        }

        public List<JobItemViewModel> GetJobsForCategoryView(JobViewSearchModel searchModel)
        {
            var q = _context.Jobs.Include(x => x.Account).Include(x => x.JobPictures)
                .Where(x => x.JobCategory == searchModel.CategoryId)
                .Where(x => x.Account.IsDeleted == false);

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
                    JobName = job.JobName,
                    JobPicture = job.JobPictures.First(x => x.IsDefault).JobPictureName,
                    JobPictureAlt = job.JobPictures.First(x => x.IsDefault).JobPictureAlt,
                    City = city.Name,
                    BenefitPercentForEndCustomer = job.JobBenefitPercentForEndCustomer
                };

            return query.ToList();
        }
    }
}