using System;
using System.Collections.Generic;
using System.Text;
using Framework;
using Okapia.Domain.Models;

namespace Okapia.Domain.Contracts
{
    public interface ICityRepository : IRepository<int, City>
    {
    }
}
