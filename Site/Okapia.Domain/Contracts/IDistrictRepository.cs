using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.District;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.District;

namespace Okapia.Domain.Contracts
{
    public interface IDistrictRepository : IRepository<int, District>
    {
        District GetDistrict(int id);
        EditDistrict GetDistrictDetails(int id);
        List<DistrictViewModel> Search(DistrictSearchModel searchModel, out int recordCount);
    }
}