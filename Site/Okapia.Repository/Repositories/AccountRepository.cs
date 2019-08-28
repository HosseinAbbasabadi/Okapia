﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class AccountRepository : BaseRepository<long, Account>, IAccountRepository
    {
        public AccountRepository(OkapiaContext context) : base(context)
        {
            _context = context;
        }

        public Account GetAccount(long id)
        {
            return _context.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public Account GetAccountByReferenceRecord(long id)
        {
            return _context.Accounts.FirstOrDefault(x => x.ReferenceRecordId == id);
        }

        public Account GetChnagePasswordInfo(long id)
        {
            return _context.Accounts.FirstOrDefault(x => x.Id == id);
        }
    }
}