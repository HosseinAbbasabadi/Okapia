﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class AccountRepository : BaseRepository<long, Account>, IAccountRepository
    {
        private readonly OkapiaContext _context;

        public AccountRepository(OkapiaContext context) : base(context)
        {
            _context = context;
        }

        public Account GetAccountByReferenceRecord(long id, int roleId)
        {
            return _context.Accounts.Where(x => x.ReferenceRecordId == id).Where(x => x.RoleId == roleId).AsNoTracking()
                .First();
        }

        public Account GetChnagePasswordInfo(long id)
        {
            return _context.Accounts.FirstOrDefault(x => x.Id == id);
        }
    }
}