using System;
using System.Collections.Generic;

namespace Okapia.Domain.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserFirstNameEn { get; set; }
        public string UserLastNameEn { get; set; }
        public string UserNationalCode { get; set; }
        public string UserPhoneNumber { get; set; }
        public int UserProvinceId { get; set; }
        public int UserCityId { get; set; }
        public int UserDistrictId { get; set; }
        public int UserNeighborhoodId { get; set; }
        public string UserAddress { get; set; }
        public string UserPostalCode { get; set; }
        public string UserEmail { get; set; }
        public DateTime? UserBirthDate { get; set; }
        public int UserCustomerIntroductionLimit { get; set; }
        public DateTime UserRegistrationDate { get; set; }
        public bool UserIsActivated { get; set; }
        public long IntroducedBy { get; set; }
        public Account Account { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
        public IList<UserCard> UserCards { get; set; }
    }
}