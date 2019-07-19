using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.Job;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;
using Okapia.Domain.ViewModels.JobPicture;

namespace Okapia.Repository.Repositories
{
    public class JobRepository : BaseRepository<long, Job>, IJobRepository
    {
        private readonly OkapiaContext _context;
        private readonly IJobPictureRepository _jobPictureRepository;

        public JobRepository(OkapiaContext context, IJobPictureRepository jobPictureRepository) : base(context)
        {
            _context = context;
            _jobPictureRepository = jobPictureRepository;
        }

        public Job GetJob(long id)
        {
            return _context.Jobs.Where(x => x.JobId == id).AsNoTracking().FirstOrDefault();
        }

        public Job GetJobIncludingAccount(long id)
        {
            return _context.Jobs.Include(x => x.Account).FirstOrDefault(x => x.JobId == id);
        }

        public EditJob GetJobDetails(long id, int roleId)
        {
            var query = from job in _context.Jobs
                join account in _context.Accounts.Where(x => x.RoleId == roleId)
                    on job.JobId equals account.ReferenceRecordId
                join category in _context.Categories
                    on job.JobCategory equals category.CategoryId
                join province in _context.Provinces
                    on job.JobProvienceId equals province.Id
                join city in _context.Cities
                    on job.JobCityId equals city.Id
                join district in _context.Districts
                    on job.JobDistrictId equals district.Id
                join neighborhood in _context.Neighborhoods
                    on job.JobNeighborhoodId equals neighborhood.Id
                where job.JobId == id
                select new EditJob
                {
                    JobId = job.JobId,
                    JobName = job.JobName,
                    JobManagerFirstName = job.JobManagerFirstName,
                    JobManagerLastName = job.JobManagerLastName,
                    JobContactTitile = job.JobContactTitile,
                    JobTel1 = job.JobTel1,
                    JobMobile1 = job.JobMobile1,
                    JobCategoryId = job.JobCategory,
                    IsDeleted = account.IsDeleted,
                    Username = account.Username,
                    JobCategory = category.CategoryName,
                    JobProvience = province.Name,
                    JobProvienceId = province.Id,
                    JobCity = city.Name,
                    JobCityId = city.Id,
                    JobDistrict = district.Name,
                    JobDistrictId = district.Id,
                    JobNeighborhood = neighborhood.Name,
                    JobneighborhoodId = neighborhood.Id,
                    JobAddress = job.JobAddress,
                    JobAccountNumber = job.JobAccountNumber,
                    CustomerIntroductionLimit = job.CustomerIntroductionLimit,
                    InstagramUrl = job.InstagramUrl,
                    TelegramUrl = job.TelegramUrl,
                    IsWebsite = job.IsWebsite,
                    JobBefitPercentForIntroducingEndCustomer = job.JobBefitPercentForIntroducingEndCustomer,
                    JobBenefitPercentForCompany = job.JobBenefitPercentForCompany,
                    JobBenefitPercentForEndCustomer = job.JobBenefitPercentForEndCustomer,
                    JobCanonicalAddress = job.JobCanonicalAddress,
                    JobContractNumber = job.JobContractNumber,
                    JobDescription = job.JobDescription,
                    JobDiscountPercentForCustomer = job.JobDiscountPercentForCustomer,
                    JobEmailAddress = job.JobEmailAddress,
                    JobMetaDesccription = job.JobMetaDesccription,
                    JobMetaTag = job.JobMetaTag,
                    JobMobile2 = job.JobMobile2,
                    JobTel2 = job.JobTel2,
                    JobPageTittle = job.JobPageTittle,
                    JobPosNameNumber = job.JobPosNameNumber,
                    JobSeohead = job.JobSeohead,
                    JobShowOrderIncategory = job.JobShowOrderIncategory,
                    JobSlug = job.JobSlug,
                    JobSmallDescription = job.JobSmallDescription,
                    JobWazeLink = job.JobWazeLink,
                    JobWazeMap = job.JobWazeMap,
                    MarketerId = job.MarketerId,
                    MarketerPercentForRegisteringShop = job.MarketerPercentForRegisteringShop,
                    ShowInHomePage = job.ShowInHomePage,
                    WebsiteUrl = job.WebSiteUrl,
                    RedirectInstead301Url = job.JobRemoved301InsteadUrl
                };

            var jobDetails = query.FirstOrDefault();

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

        public List<JobViewModel> Search(JobSearchModel searchModel, int roleId, out int recordCount)
        {
            var query = from job in _context.Jobs
                join account in _context.Accounts.Where(x => x.RoleId == roleId)
                    on job.JobId equals account.ReferenceRecordId
                join category in _context.Categories
                    on job.JobCategory equals category.CategoryId
                join province in _context.Provinces
                    on job.JobProvienceId equals province.Id
                join city in _context.Cities
                    on job.JobCityId equals city.Id
                join district in _context.Districts
                    on job.JobDistrictId equals district.Id
                join neighborhood in _context.Neighborhoods
                    on job.JobNeighborhoodId equals neighborhood.Id
                join picture in _context.JobPicture
                    on job.JobId equals picture.JobId
                where picture.IsDefault
                select new JobViewModel
                {
                    JobId = job.JobId,
                    JobName = job.JobName,
                    JobManagerFirstName = job.JobManagerFirstName,
                    JobManagerLastName = job.JobManagerLastName,
                    JobContactTitile = job.JobContactTitile,
                    JobCategoryId = job.JobCategory,
                    IsDeleted = account.IsDeleted,
                    AccountId = account.Id,
                    JobCategory = category.CategoryName,
                    JobProvience = province.Name,
                    JobProvienceId = province.Id,
                    JobCity = city.Name,
                    JobCityId = city.Id,
                    JobDistrict = district.Name,
                    JobDistrictId = district.Id,
                    JobNeighborhood = neighborhood.Name,
                    JobNeighborhoodId = neighborhood.Id,
                    JobPicture = picture.JobPictureName
                };


            query = MakeQueryConditions(searchModel, query);
            recordCount = query.Count();
            query = query.OrderByDescending(x => x.JobId).Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);
            return query.ToList();
        }

        private static IQueryable<JobViewModel> MakeQueryConditions(JobSearchModel searchModel,
            IQueryable<JobViewModel> query)
        {
            query = query.Where(x => x.IsDeleted == searchModel.IsDeleted);
            if (!string.IsNullOrEmpty(searchModel.JobName))
                query = query.Where(x => x.JobName.Contains(searchModel.JobName));
            if (!string.IsNullOrEmpty(searchModel.JobContactTitile))
                query = query.Where(x => x.JobContactTitile.Contains(searchModel.JobContactTitile));
            if (!string.IsNullOrEmpty(searchModel.JobManagerFirstName))
                query = query.Where(x => x.JobManagerFirstName.Contains(searchModel.JobManagerFirstName));
            if (!string.IsNullOrEmpty(searchModel.JobManagerLastName))
                query = query.Where(x => x.JobManagerLastName.Contains(searchModel.JobManagerLastName));
            if (!string.IsNullOrEmpty(searchModel.JobTel))
                query = query.Where(x => x.JobTel == searchModel.JobTel);
            if (!string.IsNullOrEmpty(searchModel.JobMobile))
                query = query.Where(x => x.JobMobile == searchModel.JobMobile);
            if (searchModel.JobCategoryId != 0)
                query = query.Where(x => x.JobCategoryId == searchModel.JobCategoryId);
            if (searchModel.JobProvienceId != 0)
                query = query.Where(x => x.JobProvienceId == searchModel.JobProvienceId);
            if (searchModel.JobCityId != 0)
                query = query.Where(x => x.JobCityId == searchModel.JobCityId);
            if (searchModel.JobDistrictId != 0)
                query = query.Where(x => x.JobDistrictId == searchModel.JobDistrictId);
            if (searchModel.JobNeighborhoodId != 0)
                query = query.Where(x => x.JobNeighborhoodId == searchModel.JobNeighborhoodId);
            return query;
        }
    }
}