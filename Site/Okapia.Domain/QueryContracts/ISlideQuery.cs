using System.Collections.Generic;
using Okapia.Domain.ViewModels.Slide;

namespace Okapia.Domain.QueryContracts
{
    public interface ISlideQuery
    {
        List<SliderViewModel> GetSlideShow(string province);
    }
}