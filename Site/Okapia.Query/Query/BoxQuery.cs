using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.ViewModels.Box;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Query.Query
{
    public class BoxQuery : BaseViewRepository<int, Box>, IBoxQuery
    {
        public BoxQuery(OkapiaViewContext context) : base(context)
        {
        }

        public List<BoxWithJobsViewModel> GetBoxesForLandingPage()
        {
            var boxes = _context.Boxes.Where(x => x.BoxIsEnabled).Include(x => x.BoxJobs).Select(x =>
                new BoxWithJobsViewModel
                {
                    BoxId = x.BoxId,
                    BoxIcon = x.BoxIcon,
                    BoxColor = x.BoxColor,
                    BoxLink = x.BoxLink,
                    BoxLinkText = x.BoxLinkText,
                    BoxTitle = x.BoxTitle,
                    BoxLinkBtnText = x.BoxLinkBtnText,
                    BoxBannerPicture = x.BoxBannerPicture,
                    BoxBannerPictureAlt = x.BoxBannerPictureAlt,
                    BoxBannerPictureTitle = x.BoxBannerPictureTitle,
                    BoxBannerPictureLink = x.BoxBannerPictureLink,
                    BoxBannerPictureIsEnabled = x.BoxBannerPictureIsEnabled,
                    BoxJobs = x.BoxJobs.ToList()
                }).ToList();
            foreach (var box in boxes)
            {
                var boxJobs = new List<JobItemViewModel>();
                foreach (var boxJob in box.BoxJobs)
                {
                    var jobItem = _context.Jobs.Join(_context.Cities, job => job.JobCityId, city => city.Id, (job, city) => new JobItemViewModel
                    {
                        JobId = job.JobId,
                        JobName = job.JobName,
                        JobPicture = job.JobPictures.First().JobPictureName,
                        JobPictureAlt = job.JobPictures.First().JobPictureAlt,
                        JobPictureTitle = job.JobPictures.First().JobPictureTitle,
                        JobSlug = job.JobSlug,
                        JobPrice = job.JobPrice,
                        BenefitPercentForEndCustomer = job.JobBenefitPercentForEndCustomer,
                        City = city.Name
                    }).FirstOrDefault(x=>x.JobId == boxJob.JobId);
                    boxJobs.Add(jobItem);
                }

                box.Jobs = boxJobs;
            }

            return boxes;
        }
    }
}