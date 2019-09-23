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

        public List<BoxWithJobsViewModel> GetBoxesForLandingPage(string province)
        {
            var boxes = _context.Boxes.Where(x => x.BoxIsEnabled).Join(_context.Provinces, box => box.BoxProvinceId,
                prvc => prvc.Id, (box, prvc) =>
                    new BoxWithJobsViewModel
                    {
                        BoxId = box.BoxId,
                        BoxIcon = box.BoxIcon,
                        BoxColor = box.BoxColor,
                        BoxLink = box.BoxLink,
                        BoxLinkText = box.BoxLinkText,
                        BoxTitle = box.BoxTitle,
                        BoxLinkBtnText = box.BoxLinkBtnText,
                        BoxBannerPicture = box.BoxBannerPicture,
                        BoxBannerPictureAlt = box.BoxBannerPictureAlt,
                        BoxBannerPictureTitle = box.BoxBannerPictureTitle,
                        BoxBannerPictureLink = box.BoxBannerPictureLink,
                        BoxBannerPictureIsEnabled = box.BoxBannerPictureIsEnabled,
                        BoxProvinceName = prvc.Name,
                        BoxJobs = box.BoxJobs.ToList()
                    }).Where(x => x.BoxProvinceName == province).Include(x => x.BoxJobs).ToList();
            foreach (var box in boxes)
            {
                var boxJobs = new List<JobItemViewModel>();
                foreach (var boxJob in box.BoxJobs)
                {
                    var jobItem = _context.Jobs
                        .Join(_context.Provinces, job => job.JobProvienceId, pn => pn.Id,
                            (job, pn) => new { job, pn })
                        .Join(_context.Cities, job => job.job.JobCityId, city => city.Id,
                        (job, city) => new JobItemViewModel
                        {
                            JobId = job.job.JobId,
                            JobName = job.job.JobName,
                            JobPicture = job.job.JobPictures.First().JobPictureName,
                            JobPictureAlt = job.job.JobPictures.First().JobPictureAlt,
                            JobPictureTitle = job.job.JobPictures.First().JobPictureTitle,
                            JobSlug = job.job.JobSlug,
                            JobPrice = job.job.JobPrice,
                            BenefitPercentForEndCustomer = job.job.JobBenefitPercentForEndCustomer,
                            Province = job.pn.Name,    
                            City = city.Name
                        }).FirstOrDefault(x => x.JobId == boxJob.JobId);
                    boxJobs.Add(jobItem);
                }

                box.Jobs = boxJobs;
            }

            return boxes;
        }
    }
}