using System.Collections.Generic;
using System.Linq;
using Framework;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.JobRequest;

namespace Okapia.Repository.Repositories
{
    public class JobRequestRepository : BaseRepository<long, JobRequest>, IJobRequestRepository
    {
        public JobRequestRepository(OkapiaContext context) : base(context)
        {
        }

        public JobRequest GetJobRequest(long id)
        {
            return _context.JobRequests.FirstOrDefault(x => x.Id == id);
        }

        public JobRequestViewModel GetJobRequestDetails(long id)
        {
            var query = from jobRequest in _context.JobRequests
                join province in _context.Provinces
                    on jobRequest.ProvinceId equals province.Id
                join city in _context.Cities
                    on jobRequest.CityId equals city.Id
                select new JobRequestViewModel
                {
                    Id = jobRequest.Id,
                    Name = jobRequest.Name,
                    ContactTitle = jobRequest.ContactTitle,
                    Tel = jobRequest.Tel,
                    Mobile = jobRequest.Mobile,
                    TrackingNumber = jobRequest.TrackingNumber,
                    Status = jobRequest.Status,
                    CityId = jobRequest.CityId,
                    City = city.Name,
                    ProvinceId = jobRequest.ProvinceId,
                    Province = province.Name,
                    CreationDate = jobRequest.CreationDate.ToFarsi(),
                    Address = jobRequest.Address,
                    Description = jobRequest.Description
                };
            return query.FirstOrDefault(x => x.Id == id);
        }

        public List<JobRequestViewModel> Search(JobRequestSearchModel searchModel, out int recordCount)
        {
            var query = from jobRequest in _context.JobRequests
                join province in _context.Provinces
                    on jobRequest.ProvinceId equals province.Id
                join city in _context.Cities
                    on jobRequest.CityId equals city.Id
                select new JobRequestViewModel
                {
                    Id = jobRequest.Id,
                    Name = jobRequest.Name,
                    ContactTitle = jobRequest.ContactTitle,
                    Tel = jobRequest.Tel,
                    Mobile = jobRequest.Mobile,
                    TrackingNumber = jobRequest.TrackingNumber,
                    Status = jobRequest.Status,
                    CityId = jobRequest.CityId,
                    City = city.Name,
                    ProvinceId = jobRequest.ProvinceId,
                    Province = province.Name,
                    CreationDate = jobRequest.CreationDate.ToFarsi()
                };

            if (!string.IsNullOrEmpty(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            if (!string.IsNullOrEmpty(searchModel.ContactTitle))
                query = query.Where(x => x.ContactTitle.Contains(searchModel.ContactTitle));
            if (searchModel.ProvinceId != 0)
                query = query.Where(x => x.ProvinceId == searchModel.ProvinceId);
            if (searchModel.CityId != 0)
                query = query.Where(x => x.CityId == searchModel.CityId);
            if (searchModel.TrackingNumber != 0)
                query = query.Where(x => x.TrackingNumber == searchModel.TrackingNumber);
            if (searchModel.SelectedStatus != 0)
                query = query.Where(x => x.Status == searchModel.SelectedStatus);
            recordCount = query.Count();

            query = query.OrderByDescending(x => x.Id).Skip(searchModel.PageSize * searchModel.PageIndex)
                .Take(searchModel.PageSize);

            return query.ToList();
        }
    }
}