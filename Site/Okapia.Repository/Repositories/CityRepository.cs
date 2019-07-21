using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.City;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.City;

namespace Okapia.Repository.Repositories
{
    public class CityRepository : BaseRepository<int, City>, ICityRepository
    {
        public CityRepository(OkapiaContext context) : base(context)
        {
            _context = context;
        }

        public City GetCity(int id)
        {
            return _context.Cities.Where(x => x.Id == id).AsNoTracking().ToList().First();
        }

        public EditCity GetCityDetails(int id)
        {
            var query = from city in _context.Cities
                join province in _context.Provinces
                    on city.ProvinceId equals province.Id
                where city.Id == id
                select new EditCity
                {
                    Id = city.Id,
                    Name = city.Name,
                    IsDeleted = city.IsDeleted,
                    ProvinceId = province.Id,
                    ProvinceName = province.Name
                };
            return query.ToList().First();
        }

        public List<CityViewModel> Search(CitySearchModel searchModel, out int recordCount)
        {
            var query = from city in _context.Cities
                join province in _context.Provinces
                    on city.ProvinceId equals province.Id
                select new CityViewModel
                {
                    Id = city.Id,
                    Name = city.Name,
                    ProvinceId = province.Id,
                    ProvinceName = province.Name,
                    IsDeleted = city.IsDeleted
                };

            if (!string.IsNullOrEmpty(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            if (searchModel.ProvinceId != 0)
                query = query.Where(x => x.ProvinceId == searchModel.ProvinceId);
            query = query.Where(x => x.IsDeleted == searchModel.IsDeleted);

            recordCount = query.Count();
            query = query.OrderByDescending(x => x.Id).Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);
            return query.ToList();
        }
    }
}