using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Slide;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Slide;

namespace Okapia.Domain.Contracts
{
    public interface ISlideRepository : IRepository<int, Slide>
    {
        EditSlide GetSlideDetails(int id);
        List<SlideViewModel> Search(SlideSearchModel searchModel, out int recordCount);
    }
}