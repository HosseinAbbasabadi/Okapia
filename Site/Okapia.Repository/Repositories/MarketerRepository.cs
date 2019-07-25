using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.Marketer;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Marketer;

namespace Okapia.Repository.Repositories
{
    public class MarketerRepository : BaseRepository<long, Marketer>, IMarketerRepository
    {
        public MarketerRepository(OkapiaContext context) : base(context)
        {
        }

        public Marketer GetMarketer(long id)
        {
            return _context.Marketers.AsNoTracking().FirstOrDefault(x => x.MarketerId == id);
        }

        public EditMarketer GetMarketerDetails(long id)
        {
            return _context.Marketers.Select(marketer => new EditMarketer
            {
                MarketerId = marketer.MarketerId,
                MarketerFirstName = marketer.MarketerFirstName,
                MarketerLastName = marketer.MarketerLastName,
                MarketerNationalCode = marketer.MarketerNationalCode,
                MarketerMobile = marketer.MarketerMobile,
                MarketerProvinceId = marketer.MarketerProvinceId,
                MarketerCityId = marketer.MarketerCityId,
                MarketerDistrictId = marketer.MarketerDistrictId,
                MarketerNeighborhoodId = marketer.MarketerNeighborhoodId,
                MarketerIsDeleted = marketer.MarketerIsDeleted
            }).FirstOrDefault(x => x.MarketerId == id);
        }

        public List<MarketerViewModel> Search(MarketerSearchModel searchModel, out int recordCount)
        {
            var query = from marketer in _context.Marketers
                join province in _context.Provinces
                    on marketer.MarketerProvinceId equals province.Id
                join city in _context.Cities
                    on marketer.MarketerCityId equals city.Id
                join district in _context.Districts
                    on marketer.MarketerDistrictId equals district.Id
                join neighborhood in _context.Neighborhoods
                    on marketer.MarketerNeighborhoodId equals neighborhood.Id
                select new MarketerViewModel
                {
                    MarketerId = marketer.MarketerId,
                    MarketerFullName = marketer.MarketerFirstName + " " + marketer.MarketerLastName,
                    MarketerNationalCode = marketer.MarketerNationalCode,
                    MarketerMobile = marketer.MarketerMobile,
                    MarketerProvinceId = marketer.MarketerProvinceId,
                    MarketerProvince = province.Name,
                    MarketerCityId = marketer.MarketerCityId,
                    MarketerCity = city.Name,
                    MarketerDistrictId = marketer.MarketerDistrictId,
                    MarketerDistrict = district.Name,
                    MarketerNeighborhoodId = marketer.MarketerNeighborhoodId,
                    MarketerNeighborhood = neighborhood.Name,
                    MarketerIsDeleted = marketer.MarketerIsDeleted
                };

            if (!string.IsNullOrEmpty(searchModel.MarketerFirstName))
                query = query.Where(x => x.MarketerFullName.Contains(searchModel.MarketerFirstName));
            if (!string.IsNullOrEmpty(searchModel.MarketerLastName))
                query = query.Where(x => x.MarketerFullName.Contains(searchModel.MarketerLastName));
            if (!string.IsNullOrEmpty(searchModel.MarketerNationalCode))
                query = query.Where(x => x.MarketerNationalCode.Contains(searchModel.MarketerNationalCode));
            if (!string.IsNullOrEmpty(searchModel.MarketerMobile))
                query = query.Where(x => x.MarketerMobile.Contains(searchModel.MarketerMobile));
            if (searchModel.MarketerProvinceId != 0)
                query = query.Where(x => x.MarketerProvinceId == searchModel.MarketerProvinceId);
            if (searchModel.MarketerCityId != 0)
                query = query.Where(x => x.MarketerCityId == searchModel.MarketerCityId);
            if (searchModel.MarketerDistrictId != 0)
                query = query.Where(x => x.MarketerDistrictId == searchModel.MarketerDistrictId);
            if (searchModel.MarketerNeighborhoodId != 0)
                query = query.Where(x => x.MarketerNeighborhoodId == searchModel.MarketerNeighborhoodId);
            query = query.Where(x => x.MarketerIsDeleted == searchModel.MarketerIsDeleted);

            query = query.OrderByDescending(x => x.MarketerId).Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);
            recordCount = query.Count();
            return query.ToList();
        }
    }
}