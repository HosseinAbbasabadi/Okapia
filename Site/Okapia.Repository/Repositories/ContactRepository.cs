using System.Collections.Generic;
using System.Linq;
using Framework;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.Contact;

namespace Okapia.Repository.Repositories
{
    public class ContactRepository : BaseRepository<int, Contact>, IContactRepository
    {
        public ContactRepository(OkapiaContext context) : base(context)
        {
        }

        public List<ContactViewModel> Search(ContactSearchModel searchModel, out int recordCount)
        {
            var query = _context.Contacts.Select(x => new ContactViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                CreationDate = x.CreationDate.ToFarsi(),
                IsChecked = x.IsChecked
            });

            if (!string.IsNullOrEmpty(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            if (!string.IsNullOrEmpty(searchModel.Email))
                query = query.Where(x => x.Email.Contains(searchModel.Email));
            query = query.Where(x => x.IsChecked == searchModel.IsChecked);

            recordCount = query.Count();

            query = query.OrderByDescending(x => x.Id).Skip(searchModel.PageSize * searchModel.PageIndex)
                .Take(searchModel.PageSize);
            return query.ToList();
        }

        public ContactDetailsViewModel GetDetails(int id)
        {
            return _context.Contacts.Join(_context.Accounts, contact => contact.CheckerAccountId,
                account => account.Id, (contact, account) => new ContactDetailsViewModel
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Email = contact.Email,
                    Message = contact.Message,
                    CheckerName = account.Username,
                    CreationDate = contact.CreationDate.ToFarsi(),
                    CheckDate = contact.CheckDate.ToFarsi()
                }).FirstOrDefault(x => x.Id == id);
        }
    }
}