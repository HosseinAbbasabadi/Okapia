using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class AuthInfoRepository : BaseRepository<long, AuthInfo>, IAuthInfoRepository
    {
        private readonly OkapiaContext _context;

        public AuthInfoRepository(OkapiaContext context) : base(context)
        {
            _context = context;
        }

        public AuthInfo GetAuthInfoByReferenceRecord(int id, int roleId)
        {
            return _context.AuthInfo.Where(x => x.ReferenceRecordId == id).Where(x => x.RoleId == roleId).AsNoTracking()
                .First();
        }
    }
}