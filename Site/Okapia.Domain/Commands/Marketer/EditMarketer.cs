using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.Marketer
{
    public class EditMarketer : CreateMarketer
    {
        public long MarketerId { get; set; }
        [Display(Name = "آیا حذف شود؟")] public bool MarketerIsDeleted { get; set; }
        public SelectList Cities { get; set; }
        public SelectList Districts { get; set; }
        public SelectList Neighborhoods { get; set; }
    }
}