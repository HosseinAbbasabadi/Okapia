using System.Collections.Generic;
using Framework;
using Okapia.Domain.Models;
using Okapia.Domain.ViewModels.Box;

namespace Okapia.Domain.QueryContracts
{
    public interface IBoxQuery : IRepository<int, Box>
    {
        List<BoxWithJobsViewModel> GetBoxesForLandingPage(string province);
    }
}
