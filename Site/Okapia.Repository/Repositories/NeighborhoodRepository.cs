using System;
using System.Collections.Generic;
using System.Text;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;

namespace Okapia.Repository.Repositories
{
    public class NeighborhoodRepository : BaseRepository<int, Neighborhood>, INeighborhoodRepository
    {
        public NeighborhoodRepository(OkapiaContext context) : base(context)
        {
        }
    }
}
