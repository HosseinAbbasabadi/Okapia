using System.ComponentModel.DataAnnotations;

namespace Okapia.Domain.Commands.Group
{
    public class CreateGroup
    {
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }
}
