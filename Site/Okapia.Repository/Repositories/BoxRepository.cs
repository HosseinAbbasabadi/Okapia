using System.Collections.Generic;
using System.Linq;
using Okapia.Domain.Commands.Box;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Box;

namespace Okapia.Repository.Repositories
{
    public class BoxRepository : BaseRepository<int, Box>, IBoxRepository
    {
        public BoxRepository(OkapiaContext context) : base(context)
        {
        }

        public EditBox GetDetails(int id)
        {
            return _context.Boxes.Select(x => new EditBox
            {
                BoxId = x.BoxId,
                BoxTitle = x.BoxTitle,
                BoxBannerPicture = x.BoxBannerPicture,
                BoxBannerPictureAlt = x.BoxBannerPictureAlt,
                BoxBannerPictureIsEnabled = x.BoxBannerPictureIsEnabled,
                BoxBannerPictureLink = x.BoxBannerPictureLink,
                BoxBannerPictureTitle = x.BoxBannerPictureTitle,
                BoxColor = x.BoxColor,
                BoxIcon = x.BoxIcon,
                BoxLink = x.BoxLink,
                BoxLinkBtnText = x.BoxLinkBtnText,
                BoxLinkText = x.BoxLinkText,
                BoxIsEnabled = x.BoxIsEnabled
            }).FirstOrDefault(x => x.BoxId == id);
        }

        public List<BoxViewModel> Search(BoxSearchModel searchModel, out int recordCount)
        {
            var query = _context.Boxes.Select(x => new BoxViewModel
            {
                BoxId = x.BoxId,
                BoxColor = x.BoxColor,
                BoxTitle = x.BoxTitle,
                BoxLinkText = x.BoxLinkText,
                BoxIsEnabled = x.BoxIsEnabled,
                BoxBannerPicture = x.BoxBannerPicture
            });

            if (!string.IsNullOrEmpty(searchModel.BoxTitle))
                query = query.Where(x => x.BoxTitle == searchModel.BoxTitle);
            query = query.Where(x => x.BoxIsEnabled != searchModel.BoxIsEnabled);

            recordCount = query.Count();
            query = query.OrderByDescending(x => x.BoxId).Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);
            return query.ToList();
        }
    }
}