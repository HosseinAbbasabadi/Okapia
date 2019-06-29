using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public List<JobViewModel> Search(Expression<Func<JobViewModel, bool>> conditions, JobSearchModel searchModel, out int recordCount)
        {
            var query = (from job in _context.Jobs
                join province in _context.Provinces
                    on job.JobProvienceId equals province.Id
                join city in _context.Cities
                    on job.JobProvienceId equals city.Id
                join district in _context.Districts
                    on job.JobProvienceId equals district.Id
                join neighborhood in _context.Neighborhoods
                    on job.JobProvienceId equals neighborhood.Id
                select new JobViewModel
                {
                    JobId = job.JobId,
                    JobName = job.JobName,
                    JobManagerFirstName = job.JobManagerFirstName,
                    JobManagerLastName = job.JobManagerLastName,
                    JobContactTitile = job.JobContactTitile,
                    JobProvience = province.Name,
                    JobCity = city.Name,
                    JobDistrict = district.Name,
                    JobNeighborhood = neighborhood.Name
                }).Where(conditions);
            recordCount = query.Count();
            query = query.OrderByDescending(x => x.JobId).Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);
            return query.ToList();
        }
    }
}