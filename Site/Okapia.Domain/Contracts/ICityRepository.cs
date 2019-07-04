using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.City;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.City;

namespace Okapia.Domain.Contracts
{
    public interface ICityRepository : IRepository<int, City>
    {
        City GetCity(int id);
        EditCity GetCityDetails(int id);
        List<CityViewModel> Search(CitySearchModel searchModel, out int recordCount);
    }
}
