using Okapia.Domain.Commands.Comment;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Models
{
    public class DetailsIndexViewModel
    {
        public AddComment AddComment { get; set; }
        public JobViewDetailsViewModel JobViewDetailsViewModel { get; set; }
    }
}