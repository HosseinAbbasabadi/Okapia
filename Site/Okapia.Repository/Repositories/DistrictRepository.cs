using System;
using System.Collections.Generic;
using System.Text;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class DistrictRepository : BaseRepository<int, District>, IDistrictRepository
    {
        public DistrictRepository(OkapiaContext context) : base(context)
        {
        }
    }
}
