using System;
using System.Collections.Generic;
using Framework;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Faq;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Faq;

namespace Okapia.Application.Applications
{
    public class FaqApplication : IFaqApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IFaqRepository _faqRepository;
        private readonly IJobApplication _jobApplication;

        public FaqApplication(IFaqRepository faqRepository, IAuthHelper authHelper, IJobApplication jobApplication)
        {
            _faqRepository = faqRepository;
            _authHelper = authHelper;
            _jobApplication = jobApplication;
        }

        public OperationResult Create(CreateFaq command)
        {
            var result = new OperationResult("Faqs", "Create");
            try
            {
                if (_faqRepository.IsDuplicated(x => x.Question == command.Question && x.JobId == command.JobId))
                {
                    result.Message = ApplicationMessages.DuplicatedRecord;
                    return result;
                }

                var faq = new Faq
                {
                    Question = command.Question,
                    Answer = command.Answer,
                    JobId = command.JobId,
                    CreationDate = DateTime.Now,
                    CreatorAccountId = _authHelper.GetCurrnetUserInfo().AuthUserId,
                    IsDeleted = false
                };

                _faqRepository.Create(faq);
                _faqRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public OperationResult Edit(EditFaq command)
        {
            var result = new OperationResult("Faqs", "Edit");
            try
            {
                var faq = _faqRepository.Get(command.Id);
                if (faq == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                faq.Question = command.Question;
                faq.Answer = command.Answer;
                faq.JobId = command.JobId;
                faq.IsDeleted = command.IsDeleted;

                _faqRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public OperationResult Delete(long id)
        {
            var result = new OperationResult("Faqs", "Delete");
            try
            {
                var faq = _faqRepository.Get(id);
                if (faq == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                faq.IsDeleted = true;

                _faqRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public OperationResult Activate(long id)
        {
            var result = new OperationResult("Faqs", "Delete");
            try
            {
                var faq = _faqRepository.Get(id);
                if (faq == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                faq.IsDeleted = false;

                _faqRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public EditFaq GetDetails(long id)
        {
            var faq = _faqRepository.GetDetails(id);
            faq.Jobs = new SelectList(_jobApplication.GetActiveJobs(), "JobId", "JobName");
            return faq;
        }

        public List<FaqViewModel> Search(FaqSearchModel searchModel, out int recordCount)
        {
            return _faqRepository.Search(searchModel, out recordCount);
        }
    }
}