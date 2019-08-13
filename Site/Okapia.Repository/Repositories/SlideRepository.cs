using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Okapia.Domain.Commands.Slide;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Slide;

namespace Okapia.Repository.Repositories
{
    public class SlideRepository : BaseRepository<int, Slide>, ISlideRepository
    {
        public SlideRepository(OkapiaContext context) : base(context)
        {
        }

        public EditSlide GetSlideDetails(int id)
        {
            return _context.Slides.Select(x => new EditSlide
            {
                SlideId = x.SlideId,
                SlideTitleText = x.SlideTitleText,
                SlideDescriptionText = x.SlideDescriptionText,
                SlideIsDeleted = x.SlideIsDeleted,
                SlideLink = x.SlideLink,
                AltImage = x.SlideAlt,
                TitleImage = x.SlideTitle,
                DescImage = x.SlideDescription,
                NameImage = x.SlideName
            }).FirstOrDefault(x => x.SlideId == id);
        }

        public List<SlideViewModel> Search(SlideSearchModel searchModel, out int recordCount)
        {
            var query = _context.Slides.Select(x => new SlideViewModel
            {
                SlideId = x.SlideId,
                SlideName = x.SlideName,
                SlideCreationDate = x.SlideCreationDate.ToFarsi(),
                SlideCreationDateG = x.SlideCreationDate,
                SlideIsDeleted = x.SlideIsDeleted,
                SlideTitleText = x.SlideTitleText,
                SlideDescriptionText = x.SlideDescriptionText
            });

            if (!string.IsNullOrEmpty(searchModel.SlideTitleText))
                query = query.Where(x => x.SlideTitleText == searchModel.SlideTitleText);
            if (searchModel.SlideFromCreationDateG != default(DateTime))
                query = query.Where(x => x.SlideCreationDateG >= searchModel.SlideFromCreationDateG);
            if (searchModel.SlideToCreationDateG != default(DateTime))
                query = query.Where(x => x.SlideCreationDateG <= searchModel.SlideToCreationDateG);
            query = query.Where(x => x.SlideIsDeleted == searchModel.SlideIsDeleted);

            recordCount = query.Count();

            query = query.OrderByDescending(x => x.SlideId).Skip(searchModel.PageSize * searchModel.PageIndex)
                .Take(searchModel.PageSize);
            return query.ToList();
        }
    }
}