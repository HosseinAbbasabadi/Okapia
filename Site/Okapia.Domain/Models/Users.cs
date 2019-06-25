using System;

namespace Okapia.Domain.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserNationalCode { get; set; }
        public string UserPhoneNumber { get; set; }
        public int UserProvince { get; set; }
        public int UserCity { get; set; }
        public string UserAddress { get; set; }
        public string UserPostalCode { get; set; }
        public string UserEmail { get; set; }
        public DateTime? UserBirthDate { get; set; }
        public int UserCustomerIntroductionLimit { get; set; }
        public DateTime UserRegistrationDate { get; set; }
        public bool UserIsActivated { get; set; }
    }
}