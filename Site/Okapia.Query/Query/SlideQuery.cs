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

        public List<SliderViewModel> GetSlideShow(string pn)
        {
            return _context.Slides.Where(x => x.SlideIsDeleted == false).Join(_context.Provinces, slide=> slide.SlideProvinceId, province => province.Id, (slide, province) =>  new SliderViewModel
            {
                SlideId = slide.SlideId,
                SlideName = slide.SlideName,
                SlideAlt = slide.SlideAlt,
                SlideTitle = slide.SlideTitle,
                SlideDescription = slide.SlideDescription,
                SlideLink = slide.SlideLink,
                SlideProvince = province.Name
            }).Where(x=>x.SlideProvince == pn).ToList();
        }
    }
}