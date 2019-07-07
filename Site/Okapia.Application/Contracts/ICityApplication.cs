using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.City;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.City;

namespace Okapia.Application.Contracts
{
    public interface ICityApplication
    {
        OperationResult Create(CreateCity command);
        void Delete(int id);
        void Activate(int id);
        void Update(EditCity command);
        EditCity GetCityDetails(int id);
        List<CityViewModel> GetCitiesForList(CitySearchModel searchModel, out int recordCount);
        List<CityViewModel> GetCitiesBy(int provintId);
    }
}