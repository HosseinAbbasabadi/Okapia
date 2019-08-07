using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.User;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.User;
using Z.EntityFramework.Plus;

namespace Okapia.Repository.Repositories
{
    public class UserRepository : BaseRepository<long, User>, IUserRepository
    {
        public UserRepository(OkapiaContext context) : base(context)
        {
            _context = context;
        }

        public User GetUser(long id)
        {
            return _context.Users.Include(x => x.Account).Include(x => x.UserCards).FirstOrDefault(x => x.UserId == id);
        }

        public UserDetailsViewModel GetUserInfo(long id)
        {
            var q = _context.Users.Include(x => x.Account).AsQueryable();
            var query = from user in q
                join province in _context.Provinces
                    on user.UserProvinceId equals province.Id
                join city in _context.Cities
                    on user.UserCityId equals city.Id
                join district in _context.Districts
                    on user.UserDistrictId equals district.Id
                join neighborhood in _context.Neighborhoods
                    on user.UserNeighborhoodId equals neighborhood.Id
                select new UserDetailsViewModel
                {
                    UserId = user.UserId,
                    Name = user.UserFirstName,
                    Family = user.UserLastName,
                    NameEn = user.UserFirstNameEn,
                    FamilyEn = user.UserLastNameEn,
                    UserEmail = user.UserEmail,
                    Username = user.Account.Username,
                    UserAddress = user.UserAddress,
                    UserNationalCode = user.UserNationalCode,
                    UserBirthDate = user.UserBirthDate.ToFarsi(),
                    AccountId = user.Account.Id,
                    UserRegistrationDate = user.UserRegistrationDate.ToFarsi(),
                    UserProvince = province.Name,
                    District = district.Name,
                    UserCity = city.Name,
                    Neighborhood = neighborhood.Name,
                    UserPhoneNumber = user.UserPhoneNumber,
                    UserPostalCode = user.UserPostalCode,
                    Card1 = user.UserCards[0].CardNumber,
                    Card2 = user.UserCards[1].CardNumber,
                    Card3 = user.UserCards[2].CardNumber,
                    Card4 = user.UserCards[3].CardNumber,
                    Card5 = user.UserCards[4].CardNumber,
                    Card6 = user.UserCards[5].CardNumber,
                    Card7 = user.UserCards[6].CardNumber,
                    Card8 = user.UserCards[7].CardNumber,
                    Card9 = user.UserCards[8].CardNumber,
                    Card10 = user.UserCards[9].CardNumber
                };

            return query.FirstOrDefault(x => x.UserId == id);
        }

        private UserDetailsViewModel MapToUserViewModel(User user)
        {
            return new UserDetailsViewModel
            {
            };
        }

        public EditUser GetUserDetails(long id)
        {
            var query = _context.Users.Include(x => x.Account).Include(x => x.UserCards).Select(user => new EditUser
            {
                Id = user.UserId,
                Name = user.UserFirstName,
                Family = user.UserLastName,
                NameEn = user.UserFirstNameEn,
                FamilyEn = user.UserLastNameEn,
                Username = user.Account.Username,
                NationalCardNumber = user.UserNationalCode,
                PhoneNumber = user.UserPhoneNumber,
                Address = user.UserAddress,
                ProvinceId = user.UserProvinceId,
                CityId = user.UserCityId,
                DistrictId = user.UserDistrictId,
                NeighborhoodId = user.UserNeighborhoodId,
                Postalcode = user.UserPostalCode,
                IsDeleted = user.Account.IsDeleted,
                BirthDate = user.UserBirthDate.ToFarsi(),
                Email = user.UserEmail,
                Card1 = user.UserCards[0].CardNumber,
                Card2 = user.UserCards[1].CardNumber,
                Card3 = user.UserCards[2].CardNumber,
                Card4 = user.UserCards[3].CardNumber,
                Card5 = user.UserCards[4].CardNumber,
                Card6 = user.UserCards[5].CardNumber,
                Card7 = user.UserCards[6].CardNumber,
                Card8 = user.UserCards[7].CardNumber,
                Card9 = user.UserCards[8].CardNumber,
                Card10 = user.UserCards[9].CardNumber
            }).AsQueryable();
            return query.FirstOrDefault(x => x.Id == id);
        }

        public List<User> Search(UserSearchModel searchModel)
        {
            var query = _context.Users.Include(x => x.Account).AsQueryable();

            if (!string.IsNullOrEmpty(searchModel.UserFirstName))
                query = query.Where(x => x.UserFirstName.Contains(searchModel.UserFirstName));
            if (!string.IsNullOrEmpty(searchModel.UserLastName))
                query = query.Where(x => x.UserLastName.Contains(searchModel.UserLastName));
            if (!string.IsNullOrEmpty(searchModel.Username))
                query = query.Where(x => x.Account.Username.Contains(searchModel.Username));
            if (!string.IsNullOrEmpty(searchModel.UserNationalCode))
                query = query.Where(x => x.UserNationalCode.Contains(searchModel.UserNationalCode));
            if (!string.IsNullOrEmpty(searchModel.UserPhoneNumber))
                query = query.Where(x => x.UserPhoneNumber.Contains(searchModel.UserPhoneNumber));
            if (searchModel.UserProvinceId != 0)
                query = query.Where(x => x.UserProvinceId == searchModel.UserProvinceId);
            if (searchModel.UserCityId != 0)
                query = query.Where(x => x.UserProvinceId == searchModel.UserProvinceId);
            if (searchModel.UserDistrictId != 0)
                query = query.Where(x => x.UserDistrictId == searchModel.UserDistrictId);
            if (searchModel.UserNeighborhoodId != 0)
                query = query.Where(x => x.UserNeighborhoodId == searchModel.UserNeighborhoodId);
            query = query.Where(x => x.Account.IsDeleted == searchModel.IsDeleted);
            return query.ToList();
        }

        public List<UserCardViewModel> MapUserCards(IEnumerable<UserCard> userCards)
        {
            var result = new List<UserCardViewModel>();
            userCards.ToList().ForEach(card =>
            {
                var userCard = new UserCardViewModel
                {
                    Id = card.Id,
                    CardNumber = card.CardNumber
                };
                result.Add(userCard);
            });
            return result;
        }

        public List<UserViewModel> Search(UserSearchModel searchModel, out int recordCount)
        {
            var q = _context.Users.Include(x => x.Account).AsQueryable();
            var query = from user in q
                join province in _context.Provinces
                    on user.UserProvinceId equals province.Id
                join city in _context.Cities
                    on user.UserCityId equals city.Id
                select new UserViewModel
                {
                    UserId = user.UserId,
                    UserFullName = $"{user.UserFirstName} {user.UserLastName}",
                    Username = user.Account.Username,
                    UserNationalCode = user.UserNationalCode,
                    UserPhoneNumber = user.UserPhoneNumber,
                    UserCityId = city.Id,
                    UserCity = city.Name,
                    UserProvinceId = province.Id,
                    UserProvince = province.Name,
                    UserDistrictId = user.UserDistrictId,
                    UserNeighborhoodId = user.UserNeighborhoodId,
                    UserEmail = user.UserEmail,
                    AccountId = user.Account.Id,
                    IsDeleted = user.Account.IsDeleted,
                    UserGroups = user.UserGroups.ToList()
                };

            if (!string.IsNullOrEmpty(searchModel.UserFirstName))
                query = query.Where(x => x.UserFullName.Contains(searchModel.UserFirstName));
            if (!string.IsNullOrEmpty(searchModel.UserLastName))
                query = query.Where(x => x.UserFullName.Contains(searchModel.UserLastName));
            if (!string.IsNullOrEmpty(searchModel.Username))
                query = query.Where(x => x.Username.Contains(searchModel.Username));
            if (!string.IsNullOrEmpty(searchModel.UserNationalCode))
                query = query.Where(x => x.UserNationalCode.Contains(searchModel.UserNationalCode));
            if (!string.IsNullOrEmpty(searchModel.UserPhoneNumber))
                query = query.Where(x => x.UserPhoneNumber.Contains(searchModel.UserPhoneNumber));
            if (searchModel.UserProvinceId != 0)
                query = query.Where(x => x.UserProvinceId == searchModel.UserProvinceId);
            if (searchModel.UserCityId != 0)
                query = query.Where(x => x.UserProvinceId == searchModel.UserProvinceId);
            if (searchModel.UserDistrictId != 0)
                query = query.Where(x => x.UserDistrictId == searchModel.UserDistrictId);
            if (searchModel.UserNeighborhoodId != 0)
                query = query.Where(x => x.UserNeighborhoodId == searchModel.UserNeighborhoodId);
            //if (searchModel.UserGroupId != 0)
            //    query = query.Where(x => x.UserGroups.Where(t => t.GroupId == searchModel.UserGroupId));
            query = query.Where(x => x.IsDeleted == searchModel.IsDeleted);

            recordCount = query.Count();

            query = query.OrderByDescending(x => x.UserId)
                .Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);

            return query.ToList();
        }
    }
}