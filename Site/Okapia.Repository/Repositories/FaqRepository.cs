using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.Faq;
using Okapia.Domain.Commands.Job;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Faq;

namespace Okapia.Repository.Repositories
{
    public class FaqRepository : BaseRepository<long, Faq>, IFaqRepository
    {
        public FaqRepository(OkapiaContext context) : base(context)
        {
        }

        public EditFaq GetDetails(long id)
        {
            return _context.Faqs.Select(faq => new EditFaq
            {
                Id = faq.Id,
                IsDeleted = faq.IsDeleted,
                Answer = faq.Answer,
                JobId = faq.JobId,
                Question = faq.Question
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<FaqViewModel> Search(FaqSearchModel searchModel, out int recordCount)
        {
            var query = _context.Faqs.Include(x => x.Job).Join(_context.Accounts, faq => faq.CreatorAccountId,
                account => account.Id, (faq, account) => new FaqViewModel
                {
                    Id = faq.Id,
                    Question = faq.Question,
                    CreationDate = faq.CreationDate.ToFarsi(),
                    IsDeleted = faq.IsDeleted,
                    CreatorUsername = account.Username,
                    Job = faq.Job.JobName,
                    JobId = faq.JobId
                });

            if (!string.IsNullOrEmpty(searchModel.Question))
                query = query.Where(x => x.Question == searchModel.Question);
            if (searchModel.JobId != 0)
                query = query.Where(x => x.JobId == searchModel.JobId);
            query = query.Where(x => x.IsDeleted == searchModel.IsDeleted);

            recordCount = query.Count();
            query = query.OrderByDescending(x => x.Id).Skip(searchModel.PageSize * searchModel.PageIndex)
                .Take(searchModel.PageSize);
            return query.ToList();
        }
    }
}