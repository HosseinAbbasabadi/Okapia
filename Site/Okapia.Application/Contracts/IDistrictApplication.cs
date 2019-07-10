using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.District;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels;
using Okapia.Domain.ViewModels.District;

namespace Okapia.Application.Contracts
{
    public interface IDistrictApplication
    {
        OperationResult Create(CreateDistrict command);
        OperationResult Update(EditDistrict command);
        void Delete(int id);
        void Activate(int id);
        EditDistrict GetDistrictDitails(int id);
        List<PlaceViewModel> GetDistrictsBy(int cityId);
        List<DistrictViewModel> Search(DistrictSearchModel searchModel, out int recordCount);
    }
}