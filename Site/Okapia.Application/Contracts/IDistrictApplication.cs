using System.Collections.Generic;
using Okapia.Domain.Commands.District;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.City;
using Okapia.Domain.ViewModels.District;

namespace Okapia.Application.Contracts
{
    public interface IDistrictApplication
    {
        void Create(CreateDistrict command);
        void Update(EditDistrict command);
        void Delete(int id);
        void Activate(int id);
        EditDistrict GetDistrictDitails(int id);
        List<PlaceViewModel> GetDistrictsBy(int cityId);
        List<DistrictViewModel> GetDistrictsForList(DistrictSearchModel searchModel, out int recordCount);
    }
}