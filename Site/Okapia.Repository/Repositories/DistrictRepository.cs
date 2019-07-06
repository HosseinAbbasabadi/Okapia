using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.District;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.District;

namespace Okapia.Repository.Repositories
{
    public class DistrictRepository : BaseRepository<int, District>, IDistrictRepository
    {
        private readonly OkapiaContext _context;

        public DistrictRepository(OkapiaContext context) : base(context)
        {
            _context = context;
        }

        public District GetDistrict(int id)
        {
            return _context.Districts.Where(x => x.Id == id).AsNoTracking().First();
        }

        public EditDistrict GetDistrictDetails(int id)
        {
            var query = from district in _context.Districts
                join city in _context.Cities
                    on district.CityId equals city.Id
                join province in _context.Provinces
                    on city.ProvinceId equals province.Id
                where district.Id == id
                select new EditDistrict
                {
                    Id = district.Id,
                    Name = district.Name,
                    IsDeleted = district.IsDeleted,
                    ProvinceId = province.Id,
                    ProvinceName = province.Name,
                    CityId = city.Id,
                    CityName = city.Name
                };
            return query.ToList().First();
        }

        public List<DistrictViewModel> Search(DistrictSearchModel searchModel, out int recordCount)
        {
            var query = from district in _context.Districts
                join city in _context.Cities
                    on district.CityId equals city.Id
                join province in _context.Provinces
                    on city.ProvinceId equals province.Id
                select new DistrictViewModel
                {
                    Id = district.Id,
                    Name = district.Name,
                    IsDeleted = district.IsDeleted,
                    ProvinceId = province.Id,
                    ProvinceName = province.Name,
                    CityId = city.Id,
                    CityName = city.Name
                };

            if (!string.IsNullOrEmpty(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            if (searchModel.ProvinceId != 0)
                query = query.Where(x => x.ProvinceId == searchModel.ProvinceId);
            if (searchModel.CityId != 0)
                query = query.Where(x => x.CityId == searchModel.CityId);

            query = query.Where(x => x.IsDeleted == searchModel.IsDeleted);

            recordCount = query.Count();
            query = query.OrderByDescending(x => x.Id).Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);
            return query.ToList();
        }
    }
}