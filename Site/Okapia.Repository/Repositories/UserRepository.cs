using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.User;

namespace Okapia.Repository.Repositories
{
    public class UserRepository : BaseRepository<long, User>, IUserRepository
    {
        private readonly OkapiaContext _context;

        public UserRepository(OkapiaContext context) : base(context)
        {
            _context = context;
        }

        public UserViewModel GetUserDetails(long id, int roleId)
        {
            var q = _context.Users.Include(x => x.Account).Where(x => x.Account.RoleId == roleId).AsQueryable();
            var query = from user in q
                join province in _context.Provinces
                    on user.UserProvinceId equals province.Id
                join city in _context.Cities
                    on user.UserCityId equals city.Id
                select new UserViewModel
                {
                    UserId = user.UserId,
                    UserFullName = $"{user.UserFirstName} {user.UserLastName}",
                    UserNationalCode = user.UserNationalCode,
                    UserPhoneNumber = user.UserPhoneNumber,
                    UserCityId = city.Id,
                    UserCity = city.Name,
                    UserProvinceId = province.Id,
                    UserProvince = province.Name,
                    UserEmail = user.UserEmail,
                    UserName = user.Account.Username,
                    AccountId = user.Account.Id,
                    IsDeleted = user.Account.IsDeleted,
                    UserPostalCode = user.UserPostalCode,
                    UserRegistrationDate = user.UserRegistrationDate.ToFarsi(),
                    UserAddress = user.UserAddress,
                    UserBirthDate = user.UserBirthDate.ToFarsi()
                };

            return query.FirstOrDefault(x=>x.UserId == id);
        }

        public List<UserViewModel> Search(UserSearchModel searchModel, int roleId, out int recordCount)
        {
            var q = _context.Users.Include(x => x.Account).Where(x => x.Account.RoleId == roleId).AsQueryable();
            var query = from user in q
                join province in _context.Provinces
                    on user.UserProvinceId equals province.Id
                join city in _context.Cities
                    on user.UserCityId equals city.Id
                select new UserViewModel
                {
                    UserId = user.UserId,
                    UserFullName = $"{user.UserFirstName} {user.UserLastName}",
                    UserNationalCode = user.UserNationalCode,
                    UserPhoneNumber = user.UserPhoneNumber,
                    UserCityId = city.Id,
                    UserCity = city.Name,
                    UserProvinceId = province.Id,
                    UserProvince = province.Name,
                    UserEmail = user.UserEmail,
                    UserName = user.Account.Username,
                    AccountId = user.Account.Id,
                    IsDeleted = user.Account.IsDeleted
                };

            if (!string.IsNullOrEmpty(searchModel.UserFirstName))
                query = query.Where(x => x.UserFullName.Contains(searchModel.UserFirstName));
            if (!string.IsNullOrEmpty(searchModel.UserLastName))
                query = query.Where(x => x.UserFullName.Contains(searchModel.UserLastName));
            if (!string.IsNullOrEmpty(searchModel.UserNationalCode))
                query = query.Where(x => x.UserNationalCode.Contains(searchModel.UserNationalCode));
            if (!string.IsNullOrEmpty(searchModel.UserPhoneNumber))
                query = query.Where(x => x.UserPhoneNumber.Contains(searchModel.UserPhoneNumber));
            if (searchModel.UserProvinceId != 0)
                query = query.Where(x => x.UserProvinceId == searchModel.UserProvinceId);
            if (searchModel.UserCityId != 0)
                query = query.Where(x => x.UserCityId == searchModel.UserCityId);
            query = query.Where(x => x.IsDeleted == searchModel.IsDeleted);
            query = query.OrderByDescending(x => x.UserId).Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);

            recordCount = query.Count();
            return query.ToList();
        }
    }
}