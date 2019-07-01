using System.Collections.Generic;
using System.Linq;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Repository.Repositories
{
    public class JobRepository : BaseRepository<int, Job>, IJobRepository
    {
        private readonly OkapiaContext _context;

        public JobRepository(OkapiaContext context) : base(context)
        {
            _context = context;
        }

        public List<JobViewModel> Search(JobSearchModel searchModel, out int recordCount)
        {
            var query = from job in _context.Jobs
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
                    JobTel = job.JobTel1,
                    JobMobile = job.JobMobile1,
                    JobCategoryId = job.JobCategory,
                    IsDeleted = job.IsDeleted,
                    JobCategory = category.CategoryName,
                    JobProvience = province.Name,
                    JobProvienceId = province.Id,
                    JobCity = city.Name,
                    JobCityId = city.Id,
                    JobDistrict = district.Name,
                    JobDistrictId = district.Id,
                    JobNeighborhood = neighborhood.Name,
                    JobNeighborhoodId = neighborhood.Id,
                    JobPicture = picture.JobPictureUrl
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