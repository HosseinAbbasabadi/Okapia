using System;
using System.Collections.Generic;
using System.Linq;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.ViewModels.Slide;

namespace Okapia.Query.Query
{
    public class SlideQuery : BaseViewRepository<int, Slide>, ISlideQuery
    {
        public SlideQuery(OkapiaViewContext context) : base(context)
        {
        }

        public List<SliderViewModel> GetSlideShow()
        {
            return _context.Slides.Where(x => x.SlideIsDeleted == false).Select(x => new SliderViewModel
            {
                SlideId = x.SlideId,
                SlideTitleText = x.SlideTitleText,
                SlideDescriptionText = x.SlideDescriptionText,
                SlideName = x.SlideName,
                SlideAlt = x.SlideAlt,
                SlideTitle = x.SlideTitle,
                SlideDescription = x.SlideDescription,
                SlideLink = x.SlideLink,
                SlideBtnIsVisible = x.SlideBtnIsVisible,
                SlideBtnText = x.SlideBtnText
            }).ToList();
        }
    }
}