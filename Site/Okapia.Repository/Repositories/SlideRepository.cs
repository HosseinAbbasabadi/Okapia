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
                SlideIsDeleted = x.SlideIsDeleted,
                SlideLink = x.SlideLink,
                AltImage = x.SlideAlt,
                TitleImage = x.SlideTitle,
                DescImage = x.SlideDescription,
                NameImage = x.SlideName,
                SlideProvinceId = x.SlideProvinceId
            }).FirstOrDefault(x => x.SlideId == id);
        }

        public List<SlideViewModel> Search(SlideSearchModel searchModel, out int recordCount)
        {
            var query = _context.Slides.Join(_context.Provinces, slide => slide.SlideProvinceId,
                province => province.Id, (slide, province) => new SlideViewModel
                {
                    SlideId = slide.SlideId,
                    SlideName = slide.SlideName,
                    SlideCreationDate = slide.SlideCreationDate.ToFarsi(),
                    SlideCreationDateG = slide.SlideCreationDate,
                    SlideIsDeleted = slide.SlideIsDeleted,
                    ProvinceId = slide.SlideProvinceId,
                    Province = province.Name
                });

            if (searchModel.SlideProvinceId != 0)
                query = query.Where(x => x.ProvinceId == searchModel.SlideProvinceId);
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