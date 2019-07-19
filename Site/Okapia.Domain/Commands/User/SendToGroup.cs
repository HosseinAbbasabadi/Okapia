using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.User
{
    public class SendToGroup
    {
        [Display(Name = "گروه")]
        public int GroupId { get; set; }
        public SelectList Groups { get; set; }
    }
}