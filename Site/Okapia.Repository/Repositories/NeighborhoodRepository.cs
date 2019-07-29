using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.Neighborhood;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Neighborhood;

namespace Okapia.Repository.Repositories
{
    public class NeighborhoodRepository : BaseRepository<int, Neighborhood>, INeighborhoodRepository
    {
        public NeighborhoodRepository(OkapiaContext context, OkapiaContext context1) : base(context)
        {
            _context = context1;
        }

        public Neighborhood GetNeighborhood(int id)
        {
            return _context.Neighborhoods.First(x => x.Id == id);
        }

        public EditNeighborhood GetNeighborhoodDetails(int id)
        {
            var query = from neighborhood in _context.Neighborhoods
                join district in _context.Districts
                    on neighborhood.DistrictId equals district.Id
                join city in _context.Cities
                    on district.CityId equals city.Id
                join province in _context.Provinces
                    on city.ProvinceId equals province.Id
                        where neighborhood.Id == id
                select new EditNeighborhood
                {
                    Id = neighborhood.Id,
                    Name = neighborhood.Name,
                    IsDeleted = neighborhood.IsDeleted,
                    ProvinceId = province.Id,
                    ProvinceName = province.Name,
                    CityId = city.Id,
                    CityName = city.Name,
                    DistrictId = district.Id,
                    DistrictName = district.Name
                };
            return query.First();
        }

        public List<NeighborhoodViewModel> Search(NeighborhoodSearchModel searchModel, out int recordCount)
        {
            var query = from neighborhood in _context.Neighborhoods
                join district in _context.Districts
                    on neighborhood.DistrictId equals district.Id
                join city in _context.Cities
                    on district.CityId equals city.Id
                join province in _context.Provinces
                    on city.ProvinceId equals province.Id
                select new NeighborhoodViewModel
                {
                    Id = neighborhood.Id,
                    Name = neighborhood.Name,
                    IsDeleted = neighborhood.IsDeleted,
                    ProvinceId = province.Id,
                    ProvinceName = province.Name,
                    CityId = city.Id,
                    CityName = city.Name,
                    DistrictId = district.Id,
                    DistrictName = district.Name
                };

            if (!string.IsNullOrEmpty(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            if (searchModel.ProvinceId != 0)
                query = query.Where(x => x.ProvinceId == searchModel.ProvinceId);
            if (searchModel.CityId != 0)
                query = query.Where(x => x.CityId == searchModel.CityId);
            if (searchModel.DistrictId != 0)
                query = query.Where(x => x.DistrictId == searchModel.DistrictId);

            query = query.Where(x => x.IsDeleted == searchModel.IsDeleted);

            recordCount = query.Count();
            query = query.OrderByDescending(x => x.Id).Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);
            return query.ToList();
        }
    }
}