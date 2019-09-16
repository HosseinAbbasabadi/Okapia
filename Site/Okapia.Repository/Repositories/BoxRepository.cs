using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.Box;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Box;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Repository.Repositories
{
    public class BoxRepository : BaseRepository<int, Box>, IBoxRepository
    {
        public BoxRepository(OkapiaContext context) : base(context)
        {
        }

        public EditBox GetDetails(int id)
        {
            var box = _context.Boxes.Include(x => x.BoxJobs).ThenInclude(x => x.Job).Select(x => new EditBox
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
                BoxIsEnabled = x.BoxIsEnabled,
                BoxJobs = x.BoxJobs.ToList()
            }).FirstOrDefault(x => x.BoxId == id);
            var jobs = MapBoxJobs(box);
            box.Jobs = jobs;
            return box;
        }

        public Box GetWithBoxJobs(int id)
        {
            return _context.Boxes.Include(x => x.BoxJobs).FirstOrDefault(x => x.BoxId == id);
        }

        private List<JobViewModel> MapBoxJobs(EditBox box)
        {
            var jobs = new List<JobViewModel>();

            foreach (var boxJob in box.BoxJobs)
            {
                var job = _context.Jobs.Join(_context.Categories, j => j.JobCategory, cat => cat.CategoryId,
                    (job1, category) => new JobViewModel
                    {
                        JobId = job1.JobId,
                        JobName = job1.JobName,
                        JobCategory = category.CategoryName,
                        JobPicture = job1.JobPictures.First().JobPictureName
                    }).FirstOrDefault(x => x.JobId == boxJob.JobId);
                jobs.Add(job);
            }

            return jobs;
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