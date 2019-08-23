using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.User;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.User;
using Okapia.WebService.Adapter.Contracts;

namespace Okapia.Application.Applications
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserQuery _userQuery;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccountRepository _accountRepository;
        private readonly ICityApplication _cityApplication;
        private readonly IDistrictApplication _districtApplication;
        private readonly INeighborhoodApplication _neighborhoodApplication;
        private readonly IAuthHelper _authHelper;
        private readonly IUserCardRepository _userCardRepository;
        private readonly IPasargadService _pasargadService;

        public UserApplication(IUserRepository userRepository, IPasswordHasher passwordHasher,
            IAccountRepository accountRepository, ICityApplication cityApplication,
            IDistrictApplication districtApplication, INeighborhoodApplication neighborhoodApplication,
            IAuthHelper authHelper, IUserCardRepository userCardRepository, IPasargadService pasargadService, IUserQuery userQuery)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _accountRepository = accountRepository;
            _cityApplication = cityApplication;
            _districtApplication = districtApplication;
            _neighborhoodApplication = neighborhoodApplication;
            _authHelper = authHelper;
            _userCardRepository = userCardRepository;
            _pasargadService = pasargadService;
            _userQuery = userQuery;
        }

        public OperationResult Create(CreateUser command)
        {
            var result = new OperationResult("User", "Create");
            try
            {
                if (!command.NationalCardNumber.IsValidNationalCode())
                {
                    result.Message = ApplicationMessages.InvalidNationalCode;
                    return result;
                }

                if (_accountRepository.IsDuplicated(x => x.Username == command.NationalCardNumber))
                {
                    result.Message = ApplicationMessages.DuplicatedNationalCode;
                    return result;
                }

                if (_userRepository.IsDuplicated(x => x.UserNationalCode == command.NationalCardNumber))
                {
                    result.Message = ApplicationMessages.DuplicatedNationalCode;
                    return result;
                }

                var hashedPassword = _passwordHasher.Hash(command.PhoneNumber);
                var userCards = MapCards(command);
                if (userCards.Where(x => !string.IsNullOrEmpty(x.CardNumber)).GroupBy(x => x.CardNumber)
                    .Any(x => x.Count() > 1))
                {
                    result.Message = ApplicationMessages.DuplicatedListCard;
                    return result;
                }

                foreach (var userCard in userCards.Where(x => !string.IsNullOrEmpty(x.CardNumber)))
                {
                    if (!_userCardRepository.IsDuplicated(x => x.CardNumber == userCard.CardNumber)) continue;
                    result.Message = ApplicationMessages.DuplicatedDatabaseCard;
                    return result;
                }

                if (_pasargadService.IsAlreadyRegistered(command.NationalCardNumber))
                {
                    result.Message = ApplicationMessages.UserAlreadyRegistered;
                    return result;
                }

                var account = new Account
                {
                    Username = command.NationalCardNumber,
                    Password = hashedPassword,
                    IsDeleted = false,
                    RoleId = Constants.Roles.User.Id
                };

                command.BirthDateG = command.BirthDate.ToGeorgianDateTime();
                var user = new User
                {
                    UserFirstName = command.Name,
                    UserLastName = command.Family,
                    UserFirstNameEn = command.NameEn,
                    UserLastNameEn = command.FamilyEn,
                    UserAddress = command.Address,
                    UserEmail = command.Email,
                    UserCityId = command.CityId,
                    UserProvinceId = command.ProvinceId,
                    UserDistrictId = command.DistrictId,
                    UserNeighborhoodId = command.NeighborhoodId,
                    UserBirthDate = command.BirthDateG,
                    UserNationalCode = command.NationalCardNumber,
                    UserPhoneNumber = command.PhoneNumber,
                    UserPostalCode = command.Postalcode,
                    UserRegistrationDate = DateTime.Now,
                    UserIsActivated = true,
                    UserCustomerIntroductionLimit = 200,
                    Account = account,
                    UserCards = userCards,
                    IntroducedBy = 0
                };

                _userRepository.Create(user);
                _userRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        private static List<UserCard> MapCards(CreateUser command)
        {
            var userCards = new List<UserCard>
            {
                new UserCard
                {
                    CardNumber = command.Card1
                },
                new UserCard
                {
                    CardNumber = command.Card2
                },
                new UserCard
                {
                    CardNumber = command.Card3
                },
                new UserCard
                {
                    CardNumber = command.Card4
                },
                new UserCard
                {
                    CardNumber = command.Card5
                },
                new UserCard
                {
                    CardNumber = command.Card6
                },
                new UserCard
                {
                    CardNumber = command.Card7
                },
                new UserCard
                {
                    CardNumber = command.Card8
                },
                new UserCard
                {
                    CardNumber = command.Card9
                },
                new UserCard
                {
                    CardNumber = command.Card10
                }
            };
            return userCards.OrderByDescending(x => x.CardNumber).ToList();
        }

        public OperationResult Introduce(CreateUser command)
        {
            var result = new OperationResult("User", "Create");
            try
            {
                if (!command.NationalCardNumber.IsValidNationalCode())
                {
                    result.Message = ApplicationMessages.InvalidNationalCode;
                    return result;
                }

                if (_accountRepository.IsDuplicated(x => x.Username == command.NationalCardNumber))
                {
                    result.Message = ApplicationMessages.DuplicatedUser;
                    return result;
                }

                if (_userRepository.Exists(x => x.UserNationalCode == command.NationalCardNumber))
                {
                    result.Message = ApplicationMessages.DuplicatedNationalCode;
                    return result;
                }

                var introducerId = _authHelper.GetCurrnetUserInfo().AuthUserId;
                var introducer = _userRepository.Get(x=>x.Account.Id == introducerId).First();
                if (_userRepository.Get(x => x.IntroducedBy == introducerId).Count >
                    introducer.UserCustomerIntroductionLimit)
                {
                    result.Message = ApplicationMessages.IntroducingLimitation;
                    return result;
                }

                var userCards = MapCards(command);
                if (userCards.Where(x => !string.IsNullOrEmpty(x.CardNumber)).GroupBy(x => x.CardNumber)
                    .Any(x => x.Count() > 1))
                {
                    result.Message = ApplicationMessages.DuplicatedListCard;
                    return result;
                }

                foreach (var userCard in userCards.Where(x => !string.IsNullOrEmpty(x.CardNumber)))
                {
                    if (!_userCardRepository.IsDuplicated(x => x.CardNumber == userCard.CardNumber)) continue;
                    result.Message = ApplicationMessages.DuplicatedDatabaseCard;
                    return result;
                }

                var hashedPassword = _passwordHasher.Hash(command.PhoneNumber);
                var account = new Account
                {
                    Username = command.NationalCardNumber,
                    Password = hashedPassword,
                    IsDeleted = false,
                    RoleId = Constants.Roles.User.Id
                };

                var user = new User
                {
                    UserFirstName = command.Name,
                    UserLastName = command.Family,
                    UserFirstNameEn = command.NameEn,
                    UserLastNameEn = command.FamilyEn,
                    UserNationalCode = command.NationalCardNumber,
                    UserPhoneNumber = command.PhoneNumber,
                    UserRegistrationDate = DateTime.Now,
                    UserIsActivated = true,
                    UserCustomerIntroductionLimit = 200,
                    Account = account,
                    UserCards = userCards,
                    IntroducedBy = introducerId
                };
                _userRepository.Create(user);
                _userRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public OperationResult Edit(EditUser command)
        {
            var result = new OperationResult("User", "Edit");
            try
            {
                if (!_userRepository.Exists(x => x.UserId == command.Id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var user = _userRepository.GetUser(command.Id);
                var userCards = MapCards(command);
                if (userCards.Where(x => !string.IsNullOrEmpty(x.CardNumber)).GroupBy(x => x.CardNumber)
                    .Any(x => x.Count() > 1))
                {
                    result.Message = ApplicationMessages.DuplicatedListCard;
                    return result;
                }

                foreach (var userCard in userCards.Where(x => !string.IsNullOrEmpty(x.CardNumber)))
                {
                    if (!_userCardRepository.IsDuplicated(x => x.CardNumber == userCard.CardNumber, x=>x.UserId != command.Id)) continue;
                    result.Message = ApplicationMessages.DuplicatedDatabaseCard;
                    return result;
                }

                command.BirthDateG = command.BirthDate.ToGeorgianDateTime();

                user.Account.Username = command.Username;
                user.Account.IsDeleted = command.IsDeleted;
                user.Account.RoleId = Constants.Roles.User.Id;

                user.UserFirstName = command.Name;
                user.UserLastName = command.Family;
                user.UserFirstNameEn = command.NameEn;
                user.UserLastNameEn = command.FamilyEn;
                user.UserAddress = command.Address;
                user.UserEmail = command.Email;
                user.UserCityId = command.CityId;
                user.UserProvinceId = command.ProvinceId;
                user.UserDistrictId = command.DistrictId;
                user.UserNeighborhoodId = command.NeighborhoodId;
                user.UserBirthDate = command.BirthDateG;
                user.UserNationalCode = command.NationalCardNumber;
                user.UserPhoneNumber = command.PhoneNumber;
                user.UserPostalCode = command.Postalcode;
                user.UserRegistrationDate = DateTime.Now;
                user.UserIsActivated = true;
                user.UserCustomerIntroductionLimit = 200;
                //user.UserCards = userCards;
                user.UserCards[0].CardNumber = command.Card1;
                user.UserCards[1].CardNumber = command.Card2;
                user.UserCards[2].CardNumber = command.Card3;
                user.UserCards[3].CardNumber = command.Card4;
                user.UserCards[4].CardNumber = command.Card5;
                user.UserCards[5].CardNumber = command.Card6;
                user.UserCards[6].CardNumber = command.Card7;
                user.UserCards[7].CardNumber = command.Card8;
                user.UserCards[8].CardNumber = command.Card9;
                user.UserCards[9].CardNumber = command.Card10;
                _userRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public OperationResult EditByUser(EditUser command)
        {
            var result = new OperationResult("User", "EditByUser");
            try
            {
                if (!_userRepository.Exists(x => x.UserId == command.Id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var user = _userRepository.GetUser(command.Id);
                var userCards = MapCards(command);
                if (userCards.Where(x => !string.IsNullOrEmpty(x.CardNumber)).GroupBy(x => x.CardNumber)
                    .Any(x => x.Count() > 1))
                {
                    result.Message = ApplicationMessages.DuplicatedListCard;
                    return result;
                }

                foreach (var userCard in userCards.Where(x => !string.IsNullOrEmpty(x.CardNumber)))
                {
                    if (!_userCardRepository.IsDuplicated(x => x.UserId != userCard.Id)) continue;
                    result.Message = ApplicationMessages.DuplicatedDatabaseCard;
                    return result;
                }

                command.BirthDateG = command.BirthDate.ToGeorgianDateTime();

                user.Account.Username = command.Username;

                user.UserAddress = command.Address;
                user.UserEmail = command.Email;
                user.UserCityId = command.CityId;
                user.UserProvinceId = command.ProvinceId;
                user.UserDistrictId = command.DistrictId;
                user.UserNeighborhoodId = command.NeighborhoodId;
                user.UserBirthDate = command.BirthDateG;
                user.UserPostalCode = command.Postalcode;
                user.UserCards = userCards;
                //user.UserCards[0].CardNumber = command.Card1;
                //user.UserCards[1].CardNumber = command.Card2;
                //user.UserCards[2].CardNumber = command.Card3;
                //user.UserCards[3].CardNumber = command.Card4;
                //user.UserCards[4].CardNumber = command.Card5;
                //user.UserCards[5].CardNumber = command.Card6;
                //user.UserCards[6].CardNumber = command.Card7;
                //user.UserCards[7].CardNumber = command.Card8;
                //user.UserCards[8].CardNumber = command.Card9;
                //user.UserCards[9].CardNumber = command.Card10;
                _userRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public OperationResult SendUsersToGroup(int id, UserSearchModel searchModel)
        {
            var result = new OperationResult("Users", "SendUsersToGroup");
            try
            {
                //if (!_userRepository.Exists(x => x.UserId == id))
                //{
                //    result.Message = ApplicationMessages.EntityNotExists;
                //    return result;
                //}

                //searchModel.PageSize = int.MaxValue;
                //var users = Search(searchModel, out var recordCount);
                //var group = _groupRepository.GetGroup(id);
                //group.UserGroups = MapUsersToUserGroups(id, users);

                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public EditUser GetUserDetails(long id)
        {
            var user = _userRepository.GetUserDetails(id);
            user.Cities =
                new SelectList(_cityApplication.GetCitiesBy(user.ProvinceId), "Id", "Name");
            user.Districts =
                new SelectList(_districtApplication.GetDistrictsBy(user.CityId), "Id", "Name");
            user.Neighborhoods =
                new SelectList(_neighborhoodApplication.GetNeighborhoodsBy(user.DistrictId), "Id", "Name");
            return user;
        }

        public UserDetailsViewModel GetUserInfo(long id)
        {
            return _userRepository.GetUserInfo(id);
        }

        public List<UserViewModel> Search(UserSearchModel searchModel, out int recordCount)
        {
            return _userRepository.Search(searchModel, out recordCount);
        }

        public List<IntroducedViewModel> SearchIntroduced(IntroducedSearchModel searchModel, out int recordCount)
        {
            searchModel.CurrentUserAccountId = _authHelper.GetCurrnetUserInfo().AuthUserId;
            return _userRepository.SearchIntroduced(searchModel, out recordCount);
        }

        public long GetActiveUsersCount()
        {
            return _userQuery.GetActiveUsersCount();
        }
    }
}