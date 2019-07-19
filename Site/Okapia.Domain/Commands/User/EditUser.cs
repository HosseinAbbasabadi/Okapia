using System.ComponentModel.DataAnnotations;
using Framework;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.User
{
    public class EditUser : CreateUser
    {
        private string _username;
        public long Id { get; set; }
        public SelectList Cities { get; set; }
        public SelectList Districts { get; set; }
        public SelectList Neighborhoods { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [RegularExpression("([0-9]+)", ErrorMessage = ValidationMessages.ValidPhoneNumber)]
        public string Username
        {
            get => _username;
            set => _username = value.ToEnglishNumber();
        }

        [Display(Name = "آیا حذف شود؟")] public bool IsDeleted { get; set; }
    }
}