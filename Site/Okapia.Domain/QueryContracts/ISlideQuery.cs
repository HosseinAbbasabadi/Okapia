using System;
using System.Collections.Generic;
using System.Text;
using Okapia.Domain.ViewModels.Slide;

namespace Okapia.Domain.QueryContracts
{
    public interface ISlideQuery
    {
        List<SliderViewModel> GetSlideShow();
    }
}