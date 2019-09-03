using System;
using System.Collections.Generic;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Contactus;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.Contact;

namespace Okapia.Application.Applications
{
    public class ContactApplication : IContactApplication
    {
        private readonly IContactRepository _contactRepository;
        private readonly IAuthHelper _authHelper;

        public ContactApplication(IContactRepository contactRepository, IAuthHelper authHelper)
        {
            _contactRepository = contactRepository;
            _authHelper = authHelper;
        }

        public List<ContactViewModel> Search(ContactSearchModel searchModel, out int recordCount)
        {
            return _contactRepository.Search(searchModel, out recordCount);
        }

        public OperationResult Create(CreateContact command)
        {
            var result = new OperationResult("Contactus", "Create");
            try
            {
                var contactus = new Contact
                {
                    Name = command.Name,
                    Email = command.Email,
                    Message = command.Message,
                    IsChecked = false,
                    CreationDate = DateTime.Now,
                    CheckerAccountId = 0,
                    CheckDate = DateTime.Now
                };

                _contactRepository.Create(contactus);
                _contactRepository.SaveChanges();
                result.Message = "پیام شما با موفقیت ثبت شد. باتشکر";
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

        public OperationResult Check(int id)
        {
            var result = new OperationResult("Contacts", "Check");
            try
            {
                if (!_contactRepository.Exists(x => x.Id == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var contact = _contactRepository.Get(id);
                contact.IsChecked = true;
                contact.CheckDate = DateTime.Now;
                contact.CheckerAccountId = _authHelper.GetCurrnetUserInfo().AuthUserId;
                _contactRepository.SaveChanges();
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

        public ContactDetailsViewModel GetDetails(int id)
        {
            return _contactRepository.GetDetails(id);
        }
    }
}