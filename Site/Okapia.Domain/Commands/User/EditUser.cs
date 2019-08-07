using System.ComponentModel.DataAnnotations;
using Framework;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.User
{
    public class EditUser : CreateUser
    {
        public long Id { get; set; }
        public SelectList Cities { get; set; }
        public SelectList Districts { get; set; }
        public SelectList Neighborhoods { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = ValidationMessages.EnghlishText)]
        public string Username { get; set; }

        [Display(Name = "آیا حذف شود؟")] public bool IsDeleted { get; set; }
    }
}